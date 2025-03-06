using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.Models
{
    public class PostOrderDetail
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
