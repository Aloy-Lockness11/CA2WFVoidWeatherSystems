

namespace CA2WFVoidWeatherSystems.Models
{
    public class WeatherAPIResponse
    {
        public Location location { get; set; }
        public WeatherReport report { get; set; }

        public WeatherAPIResponse()
        {
            location = new Location();
            report = new WeatherReport();
        }
    }


}
