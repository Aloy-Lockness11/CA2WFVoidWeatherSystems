
namespace CA2WFVoidWeatherSystems.Models
{
    public class WeatherReport : WeatherReportInter
    {

        public string last_updated { get; set; }
        public double temp_c { get; set; }
        public Condition condition { get; set; }
        public double wind_mph { get; set; }
        public string wind_dir { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public WeatherReport()
        {
            condition = new Condition();
            last_updated = "";
            temp_c = 0;
            wind_mph = 0;
            wind_dir = "";
            humidity = 0;
            cloud = 0;
        }

        public WeatherReport(Condition condition, string last_updated, double temp_c, double wind_mph, string wind_dir, int humidity, int cloud)
        {
            this.condition = condition;
            this.last_updated = last_updated;
            this.temp_c = temp_c;
            this.wind_mph = wind_mph;
            this.wind_dir = wind_dir;
            this.humidity = humidity;
            this.cloud = cloud;
        }

    }
}
