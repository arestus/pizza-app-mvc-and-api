using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaDetailsAPI.Migrations
{
    public partial class initialM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaID);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaID", "PizzaName", "PizzaPrice", "PizzaType" },
                values: new object[] { 1, "Margherita", 20, "Plain" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaID", "PizzaName", "PizzaPrice", "PizzaType" },
                values: new object[] { 2, "Cheeses", 30, "Cheezy" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaID", "PizzaName", "PizzaPrice", "PizzaType" },
                values: new object[] { 3, "Neapolitano", 30, "Cheezy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
