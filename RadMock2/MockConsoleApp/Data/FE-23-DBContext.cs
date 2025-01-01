using Microsoft.EntityFrameworkCore;
using MockLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockConsoleApp.Data
{
    public class FE23 : DbContext
    {
        public DbSet<Students> Students { get; set; }

        public DbSet<Grades> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RadExamJan2024;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasKey(s => s.StudentID);

            modelBuilder.Entity<Grades>()
                .HasKey(g => g.GradeID);

            modelBuilder.Entity<Students>().HasData(

                new Students { StudentID = "S00000001", FirstName = "Paul", LastName = "Brightner", DateOfBirth = new DateTime(1990, 06, 23) },
                new Students { StudentID = "S00000002", FirstName = "Millie", LastName = "Maghar", DateOfBirth = new DateTime(1989, 01, 12) },
                new Students { StudentID = "S00000003", FirstName = "Robert", LastName = "Plant", DateOfBirth = new DateTime(2003, 05, 03) }
                );

            modelBuilder.Entity<Grades>().HasData(
                new Grades { GradeID = 1, SubjectTitle = "Rich Application Development 1", Grade = 70, DateEntered = new DateTime(2024, 12, 15), StudentID = "S00000001" },
                new Grades { GradeID = 2, SubjectTitle = "Rich Application Development 2", Grade = 65, DateEntered = new DateTime(2024, 03, 15), StudentID = "S00000001" },
                new Grades { GradeID = 3, SubjectTitle = "Rich Application Development 1", Grade = 55, DateEntered = new DateTime(2024, 12, 15), StudentID = "S00000002" },
                new Grades { GradeID = 4, SubjectTitle = "Rich Application Development 2", Grade = 70, DateEntered = new DateTime(2024, 03, 15), StudentID = "S00000002" },
                new Grades { GradeID = 5, SubjectTitle = "Database Systems 2", Grade = 40, DateEntered = new DateTime(2024, 12, 10), StudentID = "S00000001" }
                );


        }
        public FE23()
        {
        }

        public FE23(DbContextOptions<FE23> options) : base(options)
        {

        }
    
}
}