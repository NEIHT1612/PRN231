using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class AuthorizeUser : User
    {
        public AuthorizeUser(User user)
        {
            EmailAddress = user.EmailAddress;
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
        public AuthorizeUser()
        {
        }
        public string AuthorizeRole { get; set; }
    }
}
