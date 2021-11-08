namespace task2.Models
{
    public class Data
    {
        public string ip { get; set; }
        public string city { get; set; }

        public Data(string ip, string city)
        {
            this.ip = ip;
            this.city = city;
        }
    }
}