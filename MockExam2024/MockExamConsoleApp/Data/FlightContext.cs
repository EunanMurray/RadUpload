using Microsoft.EntityFrameworkCore;
using MockExamClassLibrary.Models;

namespace MockExamConsoleApp
{
    public class FlightContext : DbContext
    {
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Bookings> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FlightDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Passengers>()
                .Property(p => p.PassportNumber)
                .HasMaxLength(7)
                .IsRequired();

            modelBuilder.Entity<Passengers>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.TicketPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}