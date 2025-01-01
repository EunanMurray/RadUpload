using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2022PracticePaper.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registered = table.Column<bool>(type: "bit", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "TeamName" },
                values: new object[,]
                {
                    { 1, "Under 15s" },
                    { 2, "Under 13s" },
                    { 3, "Under 20s" },
                    { 4, "Under 21s" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "DateOfBirth", "DateRegistered", "PlayerName", "Position", "Registered", "TeamID" },
                values: new object[,]
                {
                    { 1, new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elizabeth Andersen", "Goal Keeper", true, 1 },
                    { 2, new DateTime(2007, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Catherine Autier Miconi", "Right Fullback", true, 1 },
                    { 3, new DateTime(2010, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas Axen", "Goal Keeper", false, 2 },
                    { 4, new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean Philippe Bagel", "Right Fullback", false, 3 },
                    { 5, new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna Bedecs", "Goal Keeper", false, 4 },
                    { 6, new DateTime(2003, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Edwards", "Center Midfield", false, 4 },
                    { 7, new DateTime(2002, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander Eggerer", "Center Half", false, 4 },
                    { 8, new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Entin", "Left Fullback", false, 4 },
                    { 9, new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Goldschmidt", "Center Half", false, 3 },
                    { 10, new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonio Gratacos Solsona", "Center Half", false, 3 },
                    { 11, new DateTime(2003, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Grilo", "Right Midfield", false, 4 },
                    { 12, new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonas Hasselberg", "Left Midfield", false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
