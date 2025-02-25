using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int userId);
        Task<User> AddUserAsync(User newUser);
        Task<User> UpdateUserAsync(User updatedUser);
        Task DeleteUserAsync(int userId);
    }
}
