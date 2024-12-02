namespace CA2WFVoidWeatherSystems.Models
{
    public interface WeatherDayInter
    {
        DateTime Date { get; set; }
        string DayName { get; set; }
        List<WeatherReportInter> Reports { get; set; }
    }
}
