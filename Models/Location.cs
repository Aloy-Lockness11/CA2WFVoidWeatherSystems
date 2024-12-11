

namespace CA2WFVoidWeatherSystems.Models
{
    public class Location
    {
        public string name { get; set; }

        public string region { get; set; }

        public string country { get; set; }

        public double lat { get; set; }

        public double lon { get; set; }

        public string tz_id { get; set; }
      
        public long localtime_epoch { get; set; }
        
        public string localtime { get; set; }

        public Location()
        {
            name = "";
            region = "";
            country = "";
            lat = 0;
            lon = 0;
            tz_id = "";
            localtime_epoch = 0;
            localtime = "";
        }

         public Location(string name, string region, string country, double lat, double lon, string tz_id, long localtime_epoch, string localtime)
        {
            this.name = name;
            this.region = region;
            this.country = country;
            this.lat = lat;
            this.lon = lon;
            this.tz_id = tz_id;
            this.localtime_epoch = localtime_epoch;
            this.localtime = localtime;
        }
    }


}
