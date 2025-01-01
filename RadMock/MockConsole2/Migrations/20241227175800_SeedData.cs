using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MockConsole2.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightID", "Country", "DepartureDate", "Destination", "FlightNumber", "MaxSeats", "Origin" },
                values: new object[,]
                {
                    { 1, "Italy", new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Rome", "IT-001", 110, "Dublin" },
                    { 2, "England", new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "London", "EN-002", 110, "Dublin" },
                    { 3, "France", new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Paris", "FR-001", 120, "Dublin" },
                    { 4, "Belgium", new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Brussels", "BE-001", 88, "Dublin" },
                    { 5, "Ireland", new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Dublin", "DU-001", 110, "London" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerID", "Name", "PassportNumber" },
                values: new object[,]
                {
                    { 1, "FredFarnell", "P010203" },
                    { 2, "TomMcManus", "P896745" },
                    { 3, "BillTrimble", "P231425" },
                    { 4, "FredaMcDonald", "P235678" },
                    { 5, "MaryMalone", "P214587" },
                    { 6, "TomMcManus", "P893482" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "BaggageCharge", "FlightID", "PassengerID", "TicketCost", "TicketType" },
                values: new object[,]
                {
                    { 1, 30, 2, 1, 51.83m, 0 },
                    { 2, 10, 2, 2, 127m, 1 },
                    { 3, 10, 3, 3, 140m, 1 },
                    { 4, 15, 4, 4, 50m, 0 },
                    { 5, 15, 1, 5, 69m, 0 },
                    { 6, 10, 5, 6, 127m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerID",
                keyValue: 6);
        }
    }
}
