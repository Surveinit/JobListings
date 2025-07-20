using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobListings.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobListings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JobType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobListings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobListings",
                columns: new[] { "Id", "Company", "Description", "IsActive", "JobType", "Location", "PostedDate", "Salary", "Title" },
                values: new object[,]
                {
                    { 1, "Toyota", "Develop Robust web application using ASP.NET Core MVC", true, "Full-time", "Osaka, Japan", new DateTime(2025, 7, 15, 17, 26, 28, 982, DateTimeKind.Local).AddTicks(4990), 5794140m, "Software Development" },
                    { 2, "Honda", "Develop Robust low level systems using C#", true, "Full-time", "Tokyo, Japan", new DateTime(2025, 7, 17, 17, 26, 28, 982, DateTimeKind.Local).AddTicks(5933), 4282500m, "C# Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobListings");
        }
    }
}
