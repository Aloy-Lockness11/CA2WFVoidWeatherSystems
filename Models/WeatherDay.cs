namespace CA2WFVoidWeatherSystems.Models
{
    public class WeatherDay : WeatherDayInter
    {
        public DateTime Date { get; set; }
        public List<WeatherReportInter> Reports { get; set; }

        public WeatherDay()
        {
            Reports = new List<WeatherReportInter>();
        }

        public WeatherDay(DateTime date)
        {
            Date = date;
            Reports = new List<WeatherReportInter>();
        }

        public void AddReport(WeatherReportInter report)
        {
            Reports.Add(report);
        }
    }
}
