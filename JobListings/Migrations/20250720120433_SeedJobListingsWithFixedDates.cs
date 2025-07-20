using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobListings.Migrations
{
    /// <inheritdoc />
    public partial class SeedJobListingsWithFixedDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobListings",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedDate",
                value: new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "JobListings",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedDate",
                value: new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobListings",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedDate",
                value: new DateTime(2025, 7, 15, 17, 26, 28, 982, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "JobListings",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedDate",
                value: new DateTime(2025, 7, 17, 17, 26, 28, 982, DateTimeKind.Local).AddTicks(5933));
        }
    }
}
