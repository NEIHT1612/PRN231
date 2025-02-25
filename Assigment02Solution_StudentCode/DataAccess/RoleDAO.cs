using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDAO
    {
        private static RoleDAO instance;
        private static readonly object instanceLock = new object();
        public RoleDAO()
        {

        }
        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            var context = new eBookStoreContext();
            return await context.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleAsync(int roleId)
        {
            var context = new eBookStoreContext();
            return await context.Roles.FindAsync(roleId);
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            var context = new eBookStoreContext();
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
            return role;
        }
        public async Task<Role> UpdateRoleAsync(Role role)
        {
            if (await GetRoleAsync(role.RoleId) == null)
            {
                throw new Exception();
            }
            var context = new eBookStoreContext();
            context.Roles.Update(role);
            await context.SaveChangesAsync();
            return role;
        }
        public async Task DeleteRoleAsync(int roleId)
        {
            Role role = await GetRoleAsync(roleId);
            if (role == null)
            {
                throw new Exception();
            }
            var context = new eBookStoreContext();
            context.Remove(role);
            await context.SaveChangesAsync();
        }
    }
}
