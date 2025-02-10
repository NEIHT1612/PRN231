using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB.Models;

namespace WebAPICodeFirst.DB
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstrumentType>().HasData(
                new InstrumentType { InstrumentId = 1, InstrumentName = "Acoustic Guitar"},
                new InstrumentType { InstrumentId = 2, InstrumentName = "Electric Guitar"},
                new InstrumentType { InstrumentId = 3, InstrumentName = "Drums"},
                new InstrumentType { InstrumentId = 4, InstrumentName = "Bass"},
                new InstrumentType { InstrumentId = 5, InstrumentName = "Keyboard"}
            );
        }
    }
}
