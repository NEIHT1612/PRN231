using Microsoft.EntityFrameworkCore;

namespace ProgressTest6.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
