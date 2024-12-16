namespace CA2WFVoidWeatherSystems.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Text.Json;
    using CA2WFVoidWeatherSystems.Models;
    using Microsoft.Extensions.Configuration;

    public class WeatherAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherAPIService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherAPI:ApiKey"];  // Get API Key from appsettings.json

            // Log BaseAddress
            Console.WriteLine($"WeatherAPIService BaseAddress: {_httpClient.BaseAddress}");
        }

        public async Task<WeatherAPIResponse> GetWeatherCurrentBasedOnLocationDataAsync(string input, string inputType)
        {
            string requestUrl = string.Empty;

            if (inputType == "city")
            {
                requestUrl = $"current.json?key={_apiKey}&q={input}&aqi=no";
            }
            else if (inputType == "coordinates")
            {
                var coordinates = input.Split(',');
                requestUrl = $"current.json?key={_apiKey}&q={coordinates[0].Trim()},{coordinates[1].Trim()}&aqi=no";
            }
            else if (inputType == "ip")
            {
                requestUrl = $"current.json?key={_apiKey}&q={input}&aqi=no";
            }

            var response = await _httpClient.GetStringAsync(requestUrl);
            var deserializedResponse = JsonSerializer.Deserialize<JsonElement>(response);


            // Map the API response to the WeatherReport DTO
            var APIResponse = new WeatherAPIResponse
            {
                location = new Location
                {
                    name = deserializedResponse.GetProperty("location").GetProperty("name").GetString() ?? "",
                    region = deserializedResponse.GetProperty("location").GetProperty("region").GetString() ?? "",
                    country = deserializedResponse.GetProperty("location").GetProperty("country").GetString() ?? "",
                    lat = deserializedResponse.GetProperty("location").GetProperty("lat").GetDouble(),
                    lon = deserializedResponse.GetProperty("location").GetProperty("lon").GetDouble(),
                    tz_id = deserializedResponse.GetProperty("location").GetProperty("tz_id").GetString() ?? "",
                    localtime_epoch = deserializedResponse.GetProperty("location").GetProperty("localtime_epoch").GetInt64(),
                    localtime = deserializedResponse.GetProperty("location").GetProperty("localtime").GetString() ?? ""
                },

                report = new WeatherReport
                {
                    last_updated = deserializedResponse.GetProperty("current").GetProperty("last_updated").GetString() ?? "",
                    temp_c = deserializedResponse.GetProperty("current").GetProperty("temp_c").GetDouble(),
                    condition = new Condition
                    {
                        icon = deserializedResponse.GetProperty("current").GetProperty("condition").GetProperty("icon").GetString() ?? "",
                        code = deserializedResponse.GetProperty("current").GetProperty("condition").GetProperty("code").GetInt32()
                    },
                    wind_mph = deserializedResponse.GetProperty("current").GetProperty("wind_mph").GetDouble(),
                    wind_dir = deserializedResponse.GetProperty("current").GetProperty("wind_dir").GetString() ?? "",
                    humidity = deserializedResponse.GetProperty("current").GetProperty("humidity").GetInt32(),
                    cloud = deserializedResponse.GetProperty("current").GetProperty("cloud").GetInt32()
                }


            };

            return APIResponse;
        }

        public async Task<WeatherForecastAPIResponse> GetWeatherHourlyForecastAsync(string input, string inputType)
        {
            string requestUrl = string.Empty;

            if (inputType == "city")
            {
                requestUrl = $"forecast.json?key={_apiKey}&q={input}&days=3&aqi=no&alerts=no";
            }
            else if (inputType == "coordinates")
            {
                var coordinates = input.Split(',');
                requestUrl = $"forecast.json?key={_apiKey}&q={coordinates[0].Trim()},{coordinates[1].Trim()}&days=3&aqi=no&alerts=no";
            }
            else if (inputType == "ip")
            {
                requestUrl = $"forecast.json?key={_apiKey}&q={input}&days=3&aqi=no&alerts=no";
            }

            try
            {
                var response = await _httpClient.GetStringAsync(requestUrl);
                var deserializedResponse = JsonSerializer.Deserialize<JsonElement>(response);

                var WeatherResponse = new WeatherForecastAPIResponse
                {
                    location = new Location
                    {
                        name = deserializedResponse.GetProperty("location").GetProperty("name").GetString() ?? "",
                        region = deserializedResponse.GetProperty("location").GetProperty("region").GetString() ?? "",
                        country = deserializedResponse.GetProperty("location").GetProperty("country").GetString() ?? "",
                        lat = deserializedResponse.GetProperty("location").GetProperty("lat").GetDouble(),
                        lon = deserializedResponse.GetProperty("location").GetProperty("lon").GetDouble(),
                        tz_id = deserializedResponse.GetProperty("location").GetProperty("tz_id").GetString() ?? "",
                        localtime_epoch = deserializedResponse.GetProperty("location").GetProperty("localtime_epoch").GetInt64(),
                        localtime = deserializedResponse.GetProperty("location").GetProperty("localtime").GetString() ?? ""
                    },
                    current = new WeatherReport
                    {
                        last_updated = deserializedResponse.GetProperty("current").GetProperty("last_updated").GetString() ?? "",
                        temp_c = deserializedResponse.GetProperty("current").GetProperty("temp_c").GetDouble(),
                        condition = new Condition
                        {
                            icon = deserializedResponse.GetProperty("current").GetProperty("condition").GetProperty("icon").GetString() ?? "",
                            code = deserializedResponse.GetProperty("current").GetProperty("condition").GetProperty("code").GetInt32()
                        },
                        wind_mph = deserializedResponse.GetProperty("current").GetProperty("wind_mph").GetDouble(),
                        wind_dir = deserializedResponse.GetProperty("current").GetProperty("wind_dir").GetString() ?? "",
                        humidity = deserializedResponse.GetProperty("current").GetProperty("humidity").GetInt32(),
                        cloud = deserializedResponse.GetProperty("current").GetProperty("cloud").GetInt32()
                    },

                    forecastDays = new List<WeatherDay>()
                };

                var forecastDaysArray = deserializedResponse.GetProperty("forecast").GetProperty("forecastday").EnumerateArray();
                foreach (var forecastDay in forecastDaysArray)
                {
                    var weatherDay = new WeatherDay
                    {
                        Date = DateTime.Parse(forecastDay.GetProperty("date").GetString() ?? ""),
                        Reports = new List<WeatherReportInter>()
                    };

                    forecastDay.GetProperty("day");

                    // Populate hourly reports for the day
                    var hourlyReportsArray = forecastDay.GetProperty("hour").EnumerateArray();
                    foreach (var hourlyReport in hourlyReportsArray)
                    {
                        var weatherReport = new WeatherReport
                        {
                            last_updated = hourlyReport.GetProperty("time").GetString() ?? "",
                            temp_c = hourlyReport.GetProperty("temp_c").GetDouble(),
                            condition = new Condition
                            {
                                icon = hourlyReport.GetProperty("condition").GetProperty("icon").GetString() ?? "",
                                code = hourlyReport.GetProperty("condition").GetProperty("code").GetInt32()
                            },
                            wind_mph = hourlyReport.GetProperty("wind_mph").GetDouble(),
                            wind_dir = hourlyReport.GetProperty("wind_dir").GetString() ?? "",
                            humidity = hourlyReport.GetProperty("humidity").GetInt32(),
                            cloud = hourlyReport.GetProperty("cloud").GetInt32()
                            
                        };

                        // Add the hourly report to the Reports list of the weatherDay
                        weatherDay.Reports.Add(weatherReport);
                    }

                    // Add the populated weatherDay to the forecastDays list
                    WeatherResponse.forecastDays.Add(weatherDay);
                }

                return WeatherResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching hourly forecast data: {ex.Message}");
                return null;
            }
        }


    }
}
