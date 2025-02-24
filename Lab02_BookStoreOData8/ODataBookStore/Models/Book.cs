using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ODataBookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public Address Location { get; set; }
        [JsonIgnore]
        public Press Press { get; set; }
    }
}
