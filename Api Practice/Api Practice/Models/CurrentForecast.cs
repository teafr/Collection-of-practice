namespace Api_Practice.Models
{
    public class CurrentForecast
    {
        public DateTime Time { get; set; }
        public float Temperature_2m { get; set; }
        public int Is_day { get; set; }
        public int Weather_code { get; set; }
    }
}
