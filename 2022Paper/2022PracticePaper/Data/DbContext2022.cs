using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2022ClassLibrary.Models;

namespace _2022PracticePaper.Data
{
    public class DbContext2022 : DbContext
    {
        public DbSet<Players> Players { get; set; }
        public DbSet<Teams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PracticeRadExam22;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams>()
                .HasKey(t => t.TeamID);

            modelBuilder.Entity<Players>()
                .HasKey(p => p.PlayerID);

            modelBuilder.Entity<Teams>().HasData(
                new Teams { TeamID = 1, TeamName = "Under 15s" },
                new Teams { TeamID = 2, TeamName = "Under 13s" },
                new Teams { TeamID = 3, TeamName = "Under 20s" },
                new Teams { TeamID = 4, TeamName = "Under 21s" }
                );

            modelBuilder.Entity<Players>().HasData(
                new Players { PlayerID = 1, PlayerName = "Elizabeth Andersen", DateOfBirth = new DateTime(2007, 04, 01), DateRegistered = new DateTime(2023, 05, 01), Position = "Goal Keeper", Registered = true, TeamID = 1 },
                new Players { PlayerID = 2, PlayerName = "Catherine Autier Miconi", DateOfBirth = new DateTime(2007, 05, 01), DateRegistered = new DateTime(2023, 03, 01), Position = "Right Fullback", Registered = true, TeamID = 1 },
                new Players { PlayerID = 3, PlayerName = "Thomas Axen", DateOfBirth = new DateTime(2010, 04, 03), Position = "Goal Keeper", Registered = false, TeamID = 2 },
                new Players { PlayerID = 4, PlayerName = "Jean Philippe Bagel", DateOfBirth = new DateTime(2001, 03, 01), Position = "Right Fullback", Registered = false, TeamID = 3 },
                new Players { PlayerID = 5, PlayerName = "Anna Bedecs", DateOfBirth = new DateTime(2003, 06, 01), Position = "Goal Keeper", Registered = false, TeamID = 4 },
                new Players { PlayerID = 6, PlayerName = "John Edwards", DateOfBirth = new DateTime(2003, 05, 01), Position = "Center Midfield", Registered = false, TeamID = 4 },
                new Players { PlayerID = 7, PlayerName = "Alexander Eggerer", DateOfBirth = new DateTime(2002, 12, 01), Position = "Center Half", Registered = false, TeamID = 4 },
                new Players { PlayerID = 8, PlayerName = "Michael Entin", DateOfBirth = new DateTime(2003, 06, 01), Position = "Left Fullback", Registered = false, TeamID = 4 },
                new Players { PlayerID = 9, PlayerName = "Daniel Goldschmidt", DateOfBirth = new DateTime(2001, 12, 01), Position = "Center Half", Registered = false, TeamID = 3 },
                new Players { PlayerID = 10, PlayerName = "Antonio Gratacos Solsona", DateOfBirth = new DateTime(2001, 03, 01), Position = "Center Half", Registered = false, TeamID = 3 },
                new Players { PlayerID = 11, PlayerName = "Carlos Grilo", DateOfBirth = new DateTime(2003, 11, 01), Position = "Right Midfield", Registered = false, TeamID = 4 },
                new Players { PlayerID = 12, PlayerName = "Jonas Hasselberg", DateOfBirth = new DateTime(2003, 06, 01), Position = "Left Midfield", Registered = false, TeamID = 4 }
            );
        }

        public DbContext2022()
        { 
        }

        public DbContext2022(DbContextOptions<DbContext2022> options) : base(options)
        {
        }
    }
}
