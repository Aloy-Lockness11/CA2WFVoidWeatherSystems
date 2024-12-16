

namespace CA2WFVoidWeatherSystems.Models
{
    public class Condition
    {
        public string icon { get; set; }
        public int code { get; set; }

        public Condition()
        {
            icon = "";
            code = 0;
        }

        public Condition(string icon, int code)
        {
            this.icon = icon;
            this.code = code;
        }
    }

}
