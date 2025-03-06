using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.Models
{
    public class PostProduct
    {
        [Required, StringLength(40)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int UnitPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int UnitsInStock { get; set; }

        [Required]
        public int CategoryID { get; set; }

    }
}
