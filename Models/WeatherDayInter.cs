namespace CA2WFVoidWeatherSystems.Models
{
    public interface WeatherDayInter
    {
        DateTime Date { get; set; }
        List<WeatherReportInter> Reports { get; set; }
       
    }
}
