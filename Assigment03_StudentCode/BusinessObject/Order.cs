using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [ForeignKey("MemberID")]
        public string MemberID { get; set; }
        public virtual Member Member { get; set; }
        [Required]
        public int Total { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        [Required]
        public string Freight { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
