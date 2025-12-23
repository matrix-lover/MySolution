using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Lab10_Stocks
{
    public class Ticker
    {
        [Key] public int Id { get; set; }
        public string Symbol { get; set; } = "";
        
        public List<Price> Prices { get; set; } = new();
        public List<TodaysCondition> Conditions { get; set; } = new();
    }
    
    public class Price
    {
        [Key] public int Id { get; set; }
        
        public int TickerId { get; set; }
        [ForeignKey("TickerId")] public Ticker Ticker { get; set; } = null!;

        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
    
    public class TodaysCondition
    {
        [Key] public int Id { get; set; }
        
        public int TickerId { get; set; }
        [ForeignKey("TickerId")] public Ticker Ticker { get; set; } = null!;

        public string State { get; set; } = "";
        public DateTime CheckDate { get; set; }
    }
    

    public class StockContext : DbContext
    {
        public DbSet<Ticker> Tickers { get; set; } = null!;
        public DbSet<Price> Prices { get; set; } = null!;
        public DbSet<TodaysCondition> Conditions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=StocksDb;Username=postgres;Password=pass123");
        }
    }
    
    public class YahooResponse { [JsonPropertyName("chart")] public YahooChart? Chart { get; set; } }
    public class YahooChart { [JsonPropertyName("result")] public List<YahooResult>? Result { get; set; } }
    public class YahooResult 
    { 
        [JsonPropertyName("timestamp")] public List<long>? Timestamp { get; set; }
        [JsonPropertyName("indicators")] public YahooIndicators? Indicators { get; set; }
    }
    public class YahooIndicators { [JsonPropertyName("quote")] public List<YahooQuote>? Quote { get; set; } }
    public class YahooQuote { [JsonPropertyName("close")] public List<double?>? Close { get; set; } }


    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Ubuntu; Linux x86_64)");

            Console.WriteLine("Инициализация базы данных...");
            using (var db = new StockContext())
            {
                await db.Database.EnsureCreatedAsync();
            }
            Console.WriteLine("БД готова! (StocksDb)");

            while (true)
            {
                Console.Write("\nВведите тикер (например AAPL, TSLA, MSFT) или 'exit': ");
                string? input = Console.ReadLine()?.Trim().ToUpper();

                if (string.IsNullOrEmpty(input) || input == "EXIT") break;

                await ProcessStock(input);
            }
        }

        static async Task ProcessStock(string symbol)
        {
            string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?interval=1d&range=5d";
            
            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Ошибка Yahoo: {response.StatusCode}. Возможно такого тикера нет.");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<YahooResponse>(json);
                
                if (data?.Chart?.Result == null || data.Chart.Result.Count == 0) 
                {
                    Console.WriteLine("Данные пришли пустые."); 
                    return; 
                }

                var result = data.Chart.Result[0];
                var prices = result.Indicators?.Quote?[0].Close;
                var times = result.Timestamp;

                if (prices == null || prices.Count < 2)
                {
                    Console.WriteLine("Недостаточно данных для анализа.");
                    return;
                }
                
                var cleanData = new List<(DateTime Date, double Price)>();
                for (int i = 0; i < prices.Count; i++)
                {
                    if (prices[i].HasValue)
                    {
                        var date = DateTimeOffset.FromUnixTimeSeconds(times![i]).DateTime;
                        cleanData.Add((date, prices[i]!.Value));
                    }
                }

                var today = cleanData.Last();   
                var yesterday = cleanData[^2];     

          
                using (var db = new StockContext())
                {
                    var ticker = await db.Tickers.FirstOrDefaultAsync(t => t.Symbol == symbol);
                    if (ticker == null)
                    {
                        ticker = new Ticker { Symbol = symbol };
                        db.Tickers.Add(ticker);
                        await db.SaveChangesAsync();
                    }
                    
                    if (!await db.Prices.AnyAsync(p => p.TickerId == ticker.Id && p.Date == today.Date))
                    {
                        db.Prices.Add(new Price { TickerId = ticker.Id, Date = today.Date, Value = today.Price });
                    }
                    if (!await db.Prices.AnyAsync(p => p.TickerId == ticker.Id && p.Date == yesterday.Date))
                    {
                        db.Prices.Add(new Price { TickerId = ticker.Id, Date = yesterday.Date, Value = yesterday.Price });
                    }
                    await db.SaveChangesAsync();
                    
                    string status = today.Price > yesterday.Price ? "Выросла" : "Упала";
                    if (Math.Abs(today.Price - yesterday.Price) < 0.01) status = "Не изменилась";

                    var condition = new TodaysCondition
                    {
                        TickerId = ticker.Id,
                        State = status,
                        CheckDate = DateTime.Now
                    };
                    db.Conditions.Add(condition);
                    await db.SaveChangesAsync();
                    
                    Console.WriteLine($"\n--- {symbol} ---");
                    Console.WriteLine($"Цена вчера: {yesterday.Price}");
                    Console.WriteLine($"Цена сегодня: {today.Price}");
                    Console.WriteLine($"Результат: {status}");
                    Console.WriteLine("Запись успешно добавлена в PostgreSQL.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}