using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventCatalogAPI.Migrations
{
    public partial class try3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "popularEvents",
                newName: "EventName");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "eventCatalogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "eventCatalogs");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "popularEvents",
                newName: "Location");
        }
    }
}
