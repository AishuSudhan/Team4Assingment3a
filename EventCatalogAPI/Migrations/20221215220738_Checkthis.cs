using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventCatalogAPI.Migrations
{
    public partial class Checkthis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventCatagories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "popularEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_popularEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eventCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PopularEventId = table.Column<int>(type: "int", nullable: false),
                    EventCatagoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventCatalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventCatalogs_eventCatagories_EventCatagoryId",
                        column: x => x.EventCatagoryId,
                        principalTable: "eventCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventCatalogs_popularEvents_PopularEventId",
                        column: x => x.PopularEventId,
                        principalTable: "popularEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventCatalogs_EventCatagoryId",
                table: "eventCatalogs",
                column: "EventCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_eventCatalogs_PopularEventId",
                table: "eventCatalogs",
                column: "PopularEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventCatalogs");

            migrationBuilder.DropTable(
                name: "eventCatagories");

            migrationBuilder.DropTable(
                name: "popularEvents");
        }
    }
}
