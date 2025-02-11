using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("OrderId")]
        public int OrderId { get; set; }

        [JsonPropertyName("MemberId")]
        public int MemberId { get; set; }

        [JsonPropertyName("OrderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("RequiredDate")]
        public DateTime RequiredDate { get; set; }

        [JsonPropertyName("ShippedDate")]
        public DateTime ShippedDate { get; set; }

        [JsonPropertyName("Freight")]
        public decimal? Freight { get; set; }

        [JsonIgnore]
        public virtual Member? Member { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
