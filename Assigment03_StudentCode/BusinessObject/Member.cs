using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Member : IdentityUser
    {
        public string? MemberName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
