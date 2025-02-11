using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.DataAccess
{
    public partial class OrderDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("OrderId")]
        public int OrderId { get; set; }

        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }

        [JsonPropertyName("UnitPrice")]
        public decimal? UnitPrice { get; set; }

        [JsonPropertyName("Quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("Discount")]
        public decimal? Discount { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
    }
}
