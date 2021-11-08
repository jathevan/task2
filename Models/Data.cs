namespace task2.Models
{
    public class Data
    {
        public string IP { get; set; }
        public string City { get; set; }

        public Data(string ip, string city)
        {
            this.IP = ip;
            this.City = city;
        }
    }
}