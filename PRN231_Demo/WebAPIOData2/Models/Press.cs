using System.Text.Json.Serialization;

namespace WebAPIOData2.Models
{
    public class Press
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
