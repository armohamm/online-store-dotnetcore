using Newtonsoft.Json;

namespace project.Entities
{
    public class Producer
    {
        public int id { set; get; }
        public string name { set; get; }
        public string address { set; get; }
        public int rating { set; get; }
        public string note { set; get; }
    }
}