using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.Models
{
    public class PostOrder
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public string Freight { get; set; }
        [Required]
        public string MemberID { get; set; }
        [Required]
        public List<PostOrderDetail> OrderDetails { get; set; }
    }
}
