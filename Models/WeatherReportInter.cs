namespace CA2WFVoidWeatherSystems.Models
{
    public interface WeatherReportInter
    {
        Condition condition { get; set; }
        string last_updated { get; set; }
        double temp_c { get; set; }
        double wind_mph { get; set; }
        string wind_dir { get; set; }
        int humidity { get; set; }
        int cloud { get; set; }
    }
}
