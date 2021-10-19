using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderItemDetailsAPI.Migrations
{
    public partial class initialM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItemDetails",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__3C9EAF25821F4CBA", x => new { x.ItemID, x.ToppingID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemDetails");
        }
    }
}
