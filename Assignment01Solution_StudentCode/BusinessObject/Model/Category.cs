using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BusinessObject.DataAccess
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("CategoryId")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        [JsonPropertyName("CategoryName")]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
