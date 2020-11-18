using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmicWarehouse.Data.Migrations
{
    public partial class Added_ActiveFlag_To_LocationTable_WarehouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Warehouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Locations");
        }
    }
}
