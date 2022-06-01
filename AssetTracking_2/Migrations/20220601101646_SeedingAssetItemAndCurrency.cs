using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking_2.Migrations
{
    public partial class SeedingAssetItemAndCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    Country = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Shorten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.Country);
                });

            migrationBuilder.CreateTable(
                name: "assetitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCountry = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseDate = table.Column<int>(type: "int", nullable: false),
                    EndOfLife = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assetitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_assetitems_currencies_CurrencyCountry",
                        column: x => x.CurrencyCountry,
                        principalTable: "currencies",
                        principalColumn: "Country",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "Country", "Rate", "Shorten" },
                values: new object[,]
                {
                    { "Denmark", 7.0784000000000002, "DKK" },
                    { "Germany", 0.94869999999999999, "EUR" },
                    { "Spain", 0.94869999999999999, "EUR" },
                    { "Sweden", 9.9520999999999997, "SEK" },
                    { "USA", 1.0, "USD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_assetitems_CurrencyCountry",
                table: "assetitems",
                column: "CurrencyCountry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assetitems");

            migrationBuilder.DropTable(
                name: "currencies");
        }
    }
}
