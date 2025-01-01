﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MockConsoleApp.Data;

#nullable disable

namespace MockConsoleApp.Migrations
{
    [DbContext(typeof(FE23))]
    [Migration("20241228142400_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MockLibrary.Models.Grades", b =>
                {
                    b.Property<int>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeID"));

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeID = 1,
                            DateEntered = new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = 70,
                            StudentID = "S00000001",
                            SubjectTitle = "Rich Application Development 1"
                        },
                        new
                        {
                            GradeID = 2,
                            DateEntered = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = 65,
                            StudentID = "S00000001",
                            SubjectTitle = "Rich Application Development 2"
                        },
                        new
                        {
                            GradeID = 3,
                            DateEntered = new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = 55,
                            StudentID = "S00000002",
                            SubjectTitle = "Rich Application Development 1"
                        },
                        new
                        {
                            GradeID = 4,
                            DateEntered = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = 70,
                            StudentID = "S00000002",
                            SubjectTitle = "Rich Application Development 2"
                        },
                        new
                        {
                            GradeID = 5,
                            DateEntered = new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = 40,
                            StudentID = "S00000001",
                            SubjectTitle = "Database Systems 2"
                        });
                });

            modelBuilder.Entity("MockLibrary.Models.Students", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = "S00000001",
                            DateOfBirth = new DateTime(1990, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Paul",
                            LastName = "Brightner"
                        },
                        new
                        {
                            StudentID = "S00000002",
                            DateOfBirth = new DateTime(1989, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Millie",
                            LastName = "Maghar"
                        },
                        new
                        {
                            StudentID = "S00000003",
                            DateOfBirth = new DateTime(2003, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Robert",
                            LastName = "Plant"
                        });
                });

            modelBuilder.Entity("MockLibrary.Models.Grades", b =>
                {
                    b.HasOne("MockLibrary.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}