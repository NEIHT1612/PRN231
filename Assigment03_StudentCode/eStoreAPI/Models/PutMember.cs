using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.Models
{
    public class PutMember
    {
        [Required]
        public string MemberName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public string? Password { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}
