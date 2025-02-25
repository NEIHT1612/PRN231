using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ImplementRepo
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> AddUserAsync(User newUser)
            => await UserDAO.Instance.AddUserAsync(newUser);

        public async Task DeleteUserAsync(int userId)
            => await UserDAO.Instance.DeleteUserAsync(userId);

        public async Task<User> GetUserAsync(int userId)
            => await UserDAO.Instance.GetUserAsync(userId);

        public async Task<IEnumerable<User>> GetUsersAsync()
            => await UserDAO.Instance.GetUsersAsync();

        public async Task<User> UpdateUserAsync(User updatedUser)
            => await UserDAO.Instance.UpdateUserAsync(updatedUser);
    }
}
