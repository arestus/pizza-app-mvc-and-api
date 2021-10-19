using Microsoft.EntityFrameworkCore.Migrations;

namespace ToppingDetailsAPI.Migrations
{
    public partial class initialM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToppingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToppingPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingID);
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "ToppingName", "ToppingPrice" },
                values: new object[,]
                {
                    { 1, "Olives", 2 },
                    { 2, "Tomato", 5 },
                    { 3, "Onion", 4 },
                    { 4, "Cheese", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
