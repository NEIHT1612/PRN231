using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB.Models;

namespace WebAPICodeFirst.DB
{
    public class WebAPICodeFirstContext : DbContext
    {
        public WebAPICodeFirstContext(DbContextOptions<WebAPICodeFirstContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<PlayerInstrument> PlayerInstruments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasKey(p => p.PlayerId);

            modelBuilder.Entity<InstrumentType>()
                .HasKey(it => it.InstrumentId);

            modelBuilder.Entity<PlayerInstrument>()
                .HasKey(pi => pi.PlayerInstrumentId);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.playerInstruments)
                .WithOne(pi => pi.Player)
                .HasForeignKey(pi => pi.PlayerId);

            modelBuilder.Entity<PlayerInstrument>()
                .HasOne(pi => pi.InstrumentType)
                .WithMany()
                .HasForeignKey(pi => pi.InstrumentId);

            modelBuilder.Seed();
        }


    }
}
