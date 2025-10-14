using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class UniqueKeyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Unique_Key_Name_Devices",
                table: "Devices",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Unique_Key_Name_Devices",
                table: "Devices");
        }
    }
}
