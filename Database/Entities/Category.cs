using Newtonsoft.Json;

namespace project.Entities{
    
    public class Category{
        [JsonIgnore]
        public int id{set;get;}
        public string name {set;get;}
        public int categoryType{set;get;}
    }
}