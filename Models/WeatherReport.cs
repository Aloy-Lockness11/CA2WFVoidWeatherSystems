namespace CA2WFVoidWeatherSystems.Models
{
    public class WeatherReport : WeatherReportInter
    {
        public Location Location { get; set; }
        public WeatherCondition Condition { get; set; }
        public double TemperatureC { get; set; }
        public double WindSpeedMph { get; set; }
        public string WindDirection { get; set; }
        public int Humidity { get; set; }
        public int CloudCover { get; set; }
        public double FeelsLikeC { get; set; }
        public double GustSpeedMph { get; set; }
        public string LastUpdated { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
