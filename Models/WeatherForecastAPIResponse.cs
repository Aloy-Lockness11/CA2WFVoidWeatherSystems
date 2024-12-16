using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.Security.Cryptography.X509Certificates;

namespace CA2WFVoidWeatherSystems.Models
{
    public class WeatherForecastAPIResponse
    {
        public Location location { get; set; }
        public WeatherReport current { get; set; }
        public List<WeatherDay> forecastDays { get; set; }

        public WeatherForecastAPIResponse(Location location, List<WeatherDay> forecastDays)
        {
            this.location = location;
            this.forecastDays = forecastDays;
        }

        public WeatherForecastAPIResponse()
        {
            location = new Location();
            forecastDays = new List<WeatherDay>();
        }
    }
}
