namespace CA2WFVoidWeatherSystems.Models
{
    public class WeatherDay : WeatherDayInter
    {
        public DateTime Date { get; set; }
        public string DayName { get; set; }
        public List<WeatherReportInter> Reports { get; set; }

        public WeatherDay()
        {
            Reports = new List<WeatherReportInter>();
        }

        public WeatherDay(DateTime date, string dayName)
        {
            Date = date;
            DayName = dayName;
            Reports = new List<WeatherReportInter>();
        }

        public void AddReport(WeatherReportInter report)
        {
            Reports.Add(report);
        }
    }
}
