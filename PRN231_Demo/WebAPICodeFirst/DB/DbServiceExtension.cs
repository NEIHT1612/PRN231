using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace WebAPICodeFirst.DB
{
    public static class DbServiceExtension
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString) => 
            services.AddDbContext<WebAPICodeFirstContext>(d => d.UseSqlServer(connectionString));
    }
}
