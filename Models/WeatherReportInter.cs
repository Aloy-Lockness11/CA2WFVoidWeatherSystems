namespace CA2WFVoidWeatherSystems.Models
{
    public interface WeatherReportInter
    {
        Location Location { get; set; }
        WeatherCondition Condition { get; set; }
        double TemperatureC { get; set; }
        double WindSpeedMph { get; set; }
        string WindDirection { get; set; }
        int Humidity { get; set; }
        int CloudCover { get; set; }
        double FeelsLikeC { get; set; }
        double GustSpeedMph { get; set; }
        string LastUpdated { get; set; }
        DateTime ReportDate { get; set; }
    }
}
