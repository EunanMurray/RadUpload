﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2022PracticePaper.Data;

#nullable disable

namespace _2022PracticePaper.Migrations
{
    [DbContext(typeof(DbContext2022))]
    [Migration("20250101141951_InitialCreate")]
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

            modelBuilder.Entity("_2022ClassLibrary.Models.Players", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Registered")
                        .HasColumnType("bit");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerID = 1,
                            DateOfBirth = new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Elizabeth Andersen",
                            Position = "Goal Keeper",
                            Registered = true,
                            TeamID = 1
                        },
                        new
                        {
                            PlayerID = 2,
                            DateOfBirth = new DateTime(2007, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Catherine Autier Miconi",
                            Position = "Right Fullback",
                            Registered = true,
                            TeamID = 1
                        },
                        new
                        {
                            PlayerID = 3,
                            DateOfBirth = new DateTime(2010, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Thomas Axen",
                            Position = "Goal Keeper",
                            Registered = false,
                            TeamID = 2
                        },
                        new
                        {
                            PlayerID = 4,
                            DateOfBirth = new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Jean Philippe Bagel",
                            Position = "Right Fullback",
                            Registered = false,
                            TeamID = 3
                        },
                        new
                        {
                            PlayerID = 5,
                            DateOfBirth = new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Anna Bedecs",
                            Position = "Goal Keeper",
                            Registered = false,
                            TeamID = 4
                        },
                        new
                        {
                            PlayerID = 6,
                            DateOfBirth = new DateTime(2003, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "John Edwards",
                            Position = "Center Midfield",
                            Registered = false,
                            TeamID = 4
                        },
                        new
                        {
                            PlayerID = 7,
                            DateOfBirth = new DateTime(2002, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Alexander Eggerer",
                            Position = "Center Half",
                            Registered = false,
                            TeamID = 4
                        },
                        new
                        {
                            PlayerID = 8,
                            DateOfBirth = new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Michael Entin",
                            Position = "Left Fullback",
                            Registered = false,
                            TeamID = 4
                        },
                        new
                        {
                            PlayerID = 9,
                            DateOfBirth = new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Daniel Goldschmidt",
                            Position = "Center Half",
                            Registered = false,
                            TeamID = 3
                        },
                        new
                        {
                            PlayerID = 10,
                            DateOfBirth = new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Antonio Gratacos Solsona",
                            Position = "Center Half",
                            Registered = false,
                            TeamID = 3
                        },
                        new
                        {
                            PlayerID = 11,
                            DateOfBirth = new DateTime(2003, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Carlos Grilo",
                            Position = "Right Midfield",
                            Registered = false,
                            TeamID = 4
                        },
                        new
                        {
                            PlayerID = 12,
                            DateOfBirth = new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRegistered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Jonas Hasselberg",
                            Position = "Left Midfield",
                            Registered = false,
                            TeamID = 4
                        });
                });

            modelBuilder.Entity("_2022ClassLibrary.Models.Teams", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            TeamName = "Under 15s"
                        },
                        new
                        {
                            TeamID = 2,
                            TeamName = "Under 13s"
                        },
                        new
                        {
                            TeamID = 3,
                            TeamName = "Under 20s"
                        },
                        new
                        {
                            TeamID = 4,
                            TeamName = "Under 21s"
                        });
                });

            modelBuilder.Entity("_2022ClassLibrary.Models.Players", b =>
                {
                    b.HasOne("_2022ClassLibrary.Models.Teams", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("_2022ClassLibrary.Models.Teams", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
