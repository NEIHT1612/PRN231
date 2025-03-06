using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgressTest6.Models
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company { Id = Guid.NewGuid(), Address = "Thanh Xuan", Country = "VN", Name = "SMAC" },
                new Company { Id = Guid.NewGuid(), Address = "Hoa Lac", Country = "VN", Name = "FPT" }
                );
        }
    }
}
