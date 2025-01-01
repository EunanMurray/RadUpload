using Microsoft.EntityFrameworkCore;
using MockLibrary;
using MockLibrary.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace MockConsole2.Data
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
            modelBuilder.Entity<Bookings>()
                .HasKey(b => b.BookingID);

            modelBuilder.Entity<Flights>()
                .HasKey(f => f.FlightID);

            modelBuilder.Entity<Passengers>()
                .HasKey(p => p.PassengerID);

            modelBuilder.Entity<Passengers>()
                .Property(p => p.PassportNumber)
                .HasMaxLength(7)
                .IsRequired();

            modelBuilder.Entity<Passengers>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Bookings>()
                .Property(b => b.TicketCost)
                .HasPrecision(18, 2)
                .HasAnnotation("MinValue", 5);

            modelBuilder.Entity<Flights>().HasData(
                 new Flights { FlightID = 1, FlightNumber = "IT-001", DepartureDate = DateTime.Parse("2025-01-12 22:00"), Origin = "Dublin", Destination = "Rome", Country = "Italy", MaxSeats = 110 },
                 new Flights { FlightID = 2, FlightNumber = "EN-002", DepartureDate = DateTime.Parse("2025-01-12 22:00"), Origin = "Dublin", Destination = "London", Country = "England", MaxSeats = 110 },
                 new Flights { FlightID = 3, FlightNumber = "FR-001", DepartureDate = DateTime.Parse("2025-01-12 22:00"), Origin = "Dublin", Destination = "Paris", Country = "France", MaxSeats = 120 },
                 new Flights { FlightID = 4, FlightNumber = "BE-001", DepartureDate = DateTime.Parse("2025-01-12 22:00"), Origin = "Dublin", Destination = "Brussels", Country = "Belgium", MaxSeats = 88 },
                 new Flights { FlightID = 5, FlightNumber = "DU-001", DepartureDate = DateTime.Parse("2025-01-12 22:00"), Origin = "London", Destination = "Dublin", Country = "Ireland", MaxSeats = 110 }
             );

            modelBuilder.Entity<Passengers>().HasData(
                new Passengers { PassengerID = 1, Name = "FredFarnell", PassportNumber = "P010203" },
                new Passengers { PassengerID = 2, Name = "TomMcManus", PassportNumber = "P896745" },
                new Passengers { PassengerID = 3, Name = "BillTrimble", PassportNumber = "P231425" },
                new Passengers { PassengerID = 4, Name = "FredaMcDonald", PassportNumber = "P235678" },
                new Passengers { PassengerID = 5, Name = "MaryMalone", PassportNumber = "P214587" },
                new Passengers { PassengerID = 6, Name = "TomMcManus", PassportNumber = "P893482" }
            );

            modelBuilder.Entity<Bookings>().HasData(
                new Bookings { BookingID = 1, PassengerID = 1, FlightID = 2, TicketType = TicketType.Economy, TicketCost = 51.83M, BaggageCharge = 30 },
                new Bookings { BookingID = 2, PassengerID = 2, FlightID = 2, TicketType = TicketType.FirstClass, TicketCost = 127M, BaggageCharge = 10 },
                new Bookings { BookingID = 3, PassengerID = 3, FlightID = 3, TicketType = TicketType.FirstClass, TicketCost = 140M, BaggageCharge = 10 },
                new Bookings { BookingID = 4, PassengerID = 4, FlightID = 4, TicketType = TicketType.Economy, TicketCost = 50M, BaggageCharge = 15 },
                new Bookings { BookingID = 5, PassengerID = 5, FlightID = 1, TicketType = TicketType.Economy, TicketCost = 69M, BaggageCharge = 15 },
                new Bookings { BookingID = 6, PassengerID = 6, FlightID = 5, TicketType = TicketType.FirstClass, TicketCost = 127M, BaggageCharge = 10 }
            );
        }

    public FlightContext()
        {
        }
        
        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }
    }
}