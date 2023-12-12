using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorizonHotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Created_Date", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "Updated_Time" },
                values: new object[] { 1, null, "Best Villa In Town", "https://placehold.co/600x400", "Royal Villa", 4, 200.0, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
