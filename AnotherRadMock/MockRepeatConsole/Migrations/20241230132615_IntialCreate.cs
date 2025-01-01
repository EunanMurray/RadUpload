using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MockRepeatConsole.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cost = table.Column<double>(type: "float", nullable: false),
                    baggageCharge = table.Column<double>(type: "float", nullable: false),
                    FlightID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerID);
                    table.ForeignKey(
                        name: "FK_Passengers_Flights_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "FlightID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightID", "DepartureDate", "FlightNumber", "country", "destination", "maxSeats", "origin" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "IT-001", "Italy", "Rome", 110, "Dublin" },
                    { 2, new DateTime(2022, 1, 23, 12, 50, 0, 0, DateTimeKind.Unspecified), "EN-002", "England", "London", 110, "Dublin" },
                    { 3, new DateTime(2022, 1, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), "FR-001", "France", "Paris", 120, "Dublin" },
                    { 4, new DateTime(2022, 1, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), "BE-001", "Belgium", "Brussels", 88, "Dublin" },
                    { 5, new DateTime(2022, 1, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), "DU-001", "Ireland", "Dublin", 110, "London" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerID", "FlightID", "Name", "TicketType", "baggageCharge", "cost" },
                values: new object[,]
                {
                    { 1, 2, "Fred Farnell", "Economy", 30.0, 51.829999999999998 },
                    { 2, 2, "Tom Mc Manus", "First Class", 10.0, 127.0 },
                    { 3, 3, "Bill Trimble", "First Class", 10.0, 140.0 },
                    { 4, 4, "Freda Mc Donald", "Economy", 15.0, 50.920000000000002 },
                    { 5, 1, "Mary Malone", "Economy", 15.0, 66.219999999999999 },
                    { 6, 5, "Tom Mc Manus", "First Class", 10.0, 127.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_FlightID",
                table: "Passengers",
                column: "FlightID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
