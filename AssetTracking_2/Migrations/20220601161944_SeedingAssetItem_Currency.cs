using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking_2.Migrations
{
    public partial class SeedingAssetItem_Currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "assetitems",
                columns: new[] { "Id", "Brand", "CurrencyCountry", "EndOfLife", "Model", "Price", "PurchaseDate", "Type" },
                values: new object[,]
                {
                    { 1, "HP", "Spain", 20220601, "Elitebook", 1423.0, 20190601, "Computer" },
                    { 2, "HP", "Denmark", 20230526, "Elitebook", 588.0, 20200526, "Computer" },
                    { 3, "HP", "Sweden", 20230316, "Elitebook", 588.0, 20200316, "Computer" },
                    { 4, "Asus", "Spain", 20220821, "W234", 1200.0, 20190821, "Computer" },
                    { 5, "Lenovo", "USA", 20200421, "Yoga 730", 1035.0, 20170421, "Computer" },
                    { 6, "Lenovo", "USA", 20220521, "Yoga 530", 835.0, 20190521, "Computer" },
                    { 7, "iPhone", "Spain", 20211229, "8", 970.0, 20181229, "Mobile" },
                    { 8, "iPhone", "Spain", 20230925, "11", 990.0, 20200925, "Mobile" },
                    { 9, "Motorola", "Sweden", 20230315, "Razr", 970.0, 20200315, "Mobile" },
                    { 10, "iPhone", "Sweden", 20210715, "X", 1245.0, 20180715, "Mobile" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "assetitems",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
