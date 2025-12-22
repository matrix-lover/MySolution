// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http;
// using System.Text.Json;
// using System.Threading.Tasks;

// public struct Weather
// {
//     public string Country { get; set; }
//     public string Name { get; set; }
//     public double Temp { get; set; }
//     public string Description { get; set; }
// }

// class Program
// {
//     private static readonly HttpClient client = new HttpClient();
//     private static readonly Random random = new Random();
//     private const string apiKey = "c9dfcf3fd2e3de3ede8cd80a21b395d9"; 

//     static async Task Main(string[] args)
//     {
//         List<Weather> weatherList = new List<Weather>();
        
//         // Получаем 50 значений погоды
//         while (weatherList.Count < 50)
//         {
//             double lat = random.NextDouble() * 180 - 90; // -90 до 90
//             double lon = random.NextDouble() * 360 - 180; // -180 до 180
            
//             try
//             {
//                 Weather weatherData = await GetWeatherData(lat, lon);
//                 if (!string.IsNullOrEmpty(weatherData.Country) && !string.IsNullOrEmpty(weatherData.Name))
//                 {
//                     weatherList.Add(weatherData);
//                     Console.WriteLine($"Добавлено: {weatherData.Name}, {weatherData.Country}, {weatherData.Temp}°C");
//                 }
//             }
//             catch (Exception ex) // нет страны по координатам
//             {
//                 continue;
//             }
//         }

//         Console.WriteLine("\n=== АНАЛИЗ ДАННЫХ ===\n");

//         var maxTemp = weatherList.OrderByDescending(w => w.Temp).First(); // максимальная температура
//         var minTemp = weatherList.OrderBy(w => w.Temp).First(); //минимальная температура
        
//         Console.WriteLine($"1. Максимальная температура: {maxTemp.Temp}°C в {maxTemp.Name}, {maxTemp.Country}");
//         Console.WriteLine($"   Минимальная температура: {minTemp.Temp}°C в {minTemp.Name}, {minTemp.Country}");

//         double averageTemp = weatherList.Average(w => w.Temp);
//         Console.WriteLine($"\n2. Средняя температура в мире: {averageTemp:F2}°C");

//         int uniqueCountries = weatherList.Select(w => w.Country).Distinct().Count();
//         Console.WriteLine($"\n3. Количество уникальных стран: {uniqueCountries}");

//         // 4. Первые найденные места с определенными описаниями погоды
//         Console.WriteLine("\n4. Места с определенными погодными условиями:");
        
//         var clearSky = weatherList.FirstOrDefault(w => w.Description.ToLower().Contains("clear sky"));
//         if (!string.IsNullOrEmpty(clearSky.Country))
//             Console.WriteLine($"   Clear sky: {clearSky.Name}, {clearSky.Country}");
//         else
//             Console.WriteLine($"   Clear sky: не найдено");

//         var rain = weatherList.FirstOrDefault(w => w.Description.ToLower().Contains("rain"));
//         if (!string.IsNullOrEmpty(rain.Country))
//             Console.WriteLine($"   Rain: {rain.Name}, {rain.Country}");
//         else
//             Console.WriteLine($"   Rain: не найдено");

//         var fewClouds = weatherList.FirstOrDefault(w => w.Description.ToLower().Contains("few clouds"));
//         if (!string.IsNullOrEmpty(fewClouds.Country))
//             Console.WriteLine($"   Few clouds: {fewClouds.Name}, {fewClouds.Country}");
//         else
//             Console.WriteLine($"   Few clouds: не найдено");
//     }

//     static async Task<Weather> GetWeatherData(double lat, double lon)
//     {
//         string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric";
//         HttpResponseMessage response = await client.GetAsync(url);
//         response.EnsureSuccessStatusCode();
        
//         string responseBody = await response.Content.ReadAsStringAsync();
        
//         using JsonDocument doc = JsonDocument.Parse(responseBody);
//         JsonElement root = doc.RootElement;
        
//         Weather weather = new Weather
//         {
//             Country = root.TryGetProperty("sys", out var sys) ? sys.TryGetProperty("country", out var country) ? country.GetString() : "" : "",
//             Name = root.TryGetProperty("name", out var name) ? name.GetString() : "",
//             Temp = root.TryGetProperty("main", out var main) ? main.TryGetProperty("temp", out var temp) ? temp.GetDouble() : 0 : 0,
//             Description = root.TryGetProperty("weather", out var weatherArray) && weatherArray.GetArrayLength() > 0 ? weatherArray[0].TryGetProperty("description", out var desc) ? desc.GetString() : "" : ""
//         };
        
//         return weather;
//     }
// }