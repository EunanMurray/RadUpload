using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockRepeatPractice.Models;

namespace MockRepeatConsole.Data
{
    public class DbContextS00235207 : DbContext
    {
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Passengers> Passengers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PracticeRadExam30-12;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flights>()
                .HasKey(f => f.FlightID);

            modelBuilder.Entity<Passengers>()
                .HasKey(p => p.PassengerID);

            modelBuilder.Entity<Flights>().HasData(
                new Flights { FlightID = 1, FlightNumber = "IT-001", DepartureDate = new DateTime(2021, 01, 12, 22, 00, 00), origin = "Dublin", destination = "Rome", country = "Italy", maxSeats = 110 },
                new Flights { FlightID = 2, FlightNumber = "EN-002", DepartureDate = new DateTime(2022, 01, 23, 12, 50, 00), origin = "Dublin", destination = "London", country = "England", maxSeats = 110 },
                new Flights { FlightID = 3, FlightNumber = "FR-001", DepartureDate = new DateTime(2022, 01, 04, 07, 00, 00), origin = "Dublin", destination = "Paris", country = "France", maxSeats = 120 },
                new Flights { FlightID = 4, FlightNumber = "BE-001", DepartureDate = new DateTime(2022, 01, 05, 16, 30, 00), origin = "Dublin", destination = "Brussels", country = "Belgium", maxSeats = 88 },
                new Flights { FlightID = 5, FlightNumber = "DU-001", DepartureDate = new DateTime(2022, 01, 24, 11, 00, 00), origin = "London", destination = "Dublin", country = "Ireland", maxSeats = 110 }
                );

            modelBuilder.Entity<Passengers>().HasData(
                new Passengers { PassengerID = 1, Name = "Fred Farnell", TicketType = "Economy", cost = 51.83, baggageCharge = 30.00, FlightID = 2 },
                new Passengers { PassengerID = 2, Name = "Tom Mc Manus", TicketType = "First Class", cost = 127.00, baggageCharge = 10.00, FlightID = 2 },
                new Passengers { PassengerID = 3, Name = "Bill Trimble", TicketType = "First Class", cost = 140.00, baggageCharge = 10.00, FlightID = 3 },
                new Passengers { PassengerID = 4, Name = "Freda Mc Donald", TicketType = "Economy", cost = 50.92, baggageCharge = 15.00, FlightID = 4 },
                new Passengers { PassengerID = 5, Name = "Mary Malone", TicketType = "Economy", cost = 66.22, baggageCharge = 15.00, FlightID = 1 },
                new Passengers { PassengerID = 6, Name = "Tom Mc Manus", TicketType = "First Class", cost = 127.00, baggageCharge = 10.00, FlightID = 5 }
                );
        }

        public DbContextS00235207()
        {
        }

        public DbContextS00235207(DbContextOptions<DbContextS00235207> options) : base(options)
        {
        }
    }
}
