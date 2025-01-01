using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MockConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    DateEntered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "S00000001", new DateTime(1990, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul", "Brightner" },
                    { "S00000002", new DateTime(1989, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Millie", "Maghar" },
                    { "S00000003", new DateTime(2003, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Plant" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "DateEntered", "Grade", "StudentID", "SubjectTitle" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, "S00000001", "Rich Application Development 1" },
                    { 2, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, "S00000001", "Rich Application Development 2" },
                    { 3, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, "S00000002", "Rich Application Development 1" },
                    { 4, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, "S00000002", "Rich Application Development 2" },
                    { 5, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, "S00000001", "Database Systems 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
