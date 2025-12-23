using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public struct Weather
{
    public string Country { get; set; }
    public string Name { get; set; }
    public double Temp { get; set; }
    public string Description { get; set; }
}

public struct City
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
}

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private static List<City> cities = new List<City>();
    private const string apiKey = "a302ffed2f1e25d55fc76eb74f513600";
    private const string cityFileName = "city.txt";

    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        LoadCitiesFromFile();

        bool exitRequested = false;
        while (!exitRequested)
        {
            Console.Clear();
            Console.WriteLine("=== ПРИЛОЖЕНИЕ ПОГОДЫ ===");
            Console.WriteLine("Список доступных городов:");
            Console.WriteLine("=========================");
            
            for (int i = 0; i < cities.Count; i++)
            {
                string displayName = !string.IsNullOrEmpty(cities[i].DisplayName)
                    ? cities[i].DisplayName
                    : cities[i].Name;

                Console.WriteLine($"{i + 1}. {displayName} ({cities[i].Lat:F2}, {cities[i].Lon:F2})");
            }

            Console.WriteLine("\n=========================");
            Console.WriteLine("Введите номер города для получения погоды (или 'q' для выхода):");

            string input = Console.ReadLine();

            if (input?.ToLower() == "q")
            {
                exitRequested = true;
                continue;
            }

            if (int.TryParse(input, out int cityNumber) && cityNumber >= 1 && cityNumber <= cities.Count)
            {
                City selectedCity = cities[cityNumber - 1];
                string displayCityName = !string.IsNullOrEmpty(selectedCity.DisplayName) 
                    ? selectedCity.DisplayName 
                    : selectedCity.Name;
                
                Console.WriteLine($"\nЗагрузка погоды для {displayCityName}...");
                
                try
                {
                    Weather weather = await GetWeatherData(selectedCity.Lat, selectedCity.Lon);
                    
                    Console.WriteLine("\n=== РЕЗУЛЬТАТЫ ПОГОДЫ ===");
                    Console.WriteLine($"Город (по данным API): {weather.Name}");
                    Console.WriteLine($"Город (из файла): {displayCityName}");
                    Console.WriteLine($"Страна: {weather.Country}");
                    Console.WriteLine($"Температура: {weather.Temp}°C");
                    Console.WriteLine($"Описание: {weather.Description}");
                    Console.WriteLine("=========================");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nОшибка при загрузке погоды: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("\nНеверный ввод. Пожалуйста, введите номер города из списка.");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
    static void LoadCitiesFromFile()
    {
        try
        {
            if (!File.Exists(cityFileName))
            {
                CreateSampleCityFile();
                Console.WriteLine($"Файл {cityFileName} не найден. Создан пример файла.");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
            string[] lines = File.ReadAllLines(cityFileName, Encoding.UTF8);
            cities.Clear();

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
                    continue;
                string[] parts = trimmedLine.Split(',');
                
                if (parts.Length >= 3)
                {
                    City city = new City();
                    
                    if (parts.Length >= 4)
                    {
                        city.Name = parts[0].Trim();
                        city.DisplayName = parts[1].Trim();
                        if (double.TryParse(parts[2], out double lat) && double.TryParse(parts[3], out double lon))
                        {
                            city.Lat = lat;
                            city.Lon = lon;
                            cities.Add(city);
                        }
                    }
                    else if (parts.Length == 3)
                    {
                        city.Name = parts[0].Trim();
                        city.DisplayName = parts[0].Trim();
                        if (double.TryParse(parts[1], out double lat) && double.TryParse(parts[2], out double lon))
                        {
                            city.Lat = lat;
                            city.Lon = lon;
                            cities.Add(city);
                        }
                    }
                }
            }

            Console.WriteLine($"Загружено {cities.Count} городов.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла {cityFileName}: {ex.Message}");
        }
    }

    static void CreateSampleCityFile()
    {
        string[] sampleCities = {
            "# Формат: ИмяДляAPI,ОтображаемоеИмя,широта,долгота",
            "# или: Имя,широта,долгота",
            "Moscow,Москва,55.7558,37.6173",
            "New York,Нью-Йорк,40.7128,-74.0060",
            "London,Лондон,51.5074,-0.1278"
        };
        
        File.WriteAllLines(cityFileName, sampleCities, Encoding.UTF8);
    }

    static async Task<Weather> GetWeatherData(double lat, double lon)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric&lang=ru";
        HttpResponseMessage response = await client.GetAsync(url);
        
        if (!response.IsSuccessStatusCode)
        {
            string errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Ошибка API: {response.StatusCode}. {errorContent}");
        }
        
        string responseBody = await response.Content.ReadAsStringAsync();
        
        using JsonDocument doc = JsonDocument.Parse(responseBody);
        JsonElement root = doc.RootElement;
        
        Weather weather = new Weather
        {
            Country = root.TryGetProperty("sys", out var sys) ? sys.TryGetProperty("country", out var country) ? country.GetString() : "" : "",
            Name = root.TryGetProperty("name", out var name) ? name.GetString() : "",
            Temp = root.TryGetProperty("main", out var main) ? main.TryGetProperty("temp", out var temp) ? temp.GetDouble() : 0 : 0,
            Description = root.TryGetProperty("weather", out var weatherArray) && weatherArray.GetArrayLength() > 0 ? weatherArray[0].TryGetProperty("description", out var desc) ? desc.GetString() : "" : ""
        };
        
        return weather;
    }
}