using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorizonHotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyVillaFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Villas",
                newName: "Updated_Time");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Villas",
                newName: "Created_Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_Time",
                table: "Villas",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "Created_Date",
                table: "Villas",
                newName: "CreatedDate");
        }
    }
}
