using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(40)]
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [Required]
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
        [Required]
        [JsonPropertyName("unitInStock")]
        public int UnitInStock { get; set; }
        [Required]
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }

        public static implicit operator List<object>(Product? v)
        {
            throw new NotImplementedException();
        }
    }
}
