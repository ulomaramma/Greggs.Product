using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Greggs.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "BREAKFAST" },
                    { 2, "HOT FOOD" },
                    { 3, "SAVOURIES & BAKES" },
                    { 4, "DRINKS & SNACKS" },
                    { 5, "SANDWICHES & SALADS" },
                    { 6, "SWEET TREATS" }
                });

            migrationBuilder.InsertData(
                table: "Nutrients",
                columns: new[] { "NutrientID", "Name", "Unit" },
                values: new object[,]
                {
                    { 1, "Carbohydrates", "g" },
                    { 2, "Protein", "g" },
                    { 3, "Fats", "g" },
                    { 4, "Energy kJ", "kcal" },
                    { 5, "Energy kcal", "kJ" },
                    { 6, "Sugars", "g" },
                    { 7, "Salt", "g" },
                    { 8, "of which Saturates", "g" },
                    { 9, "of which Sugars", "g" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedDate", "Description", "IsDeleted", "PriceInPounds", "ProductName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4755), "A delicious sausage roll.", false, 1m, "Sausage Roll", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4951) },
                    { 2, 3, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4962), "A tasty vegan sausage roll.", false, 1.1m, "Vegan Sausage Roll", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4963) },
                    { 3, 3, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4967), "A savory steak bake.", false, 1.2m, "Steak Bake", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4968) },
                    { 4, 6, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4970), "A sweet treat.", false, 0.7m, "Yum Yum", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4972) },
                    { 5, 6, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4974), "A delicious pink jammie.", false, 0.5m, "Pink Jammie", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4975) },
                    { 6, 5, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4978), "A spicy Mexican baguette.", false, 2.1m, "Mexican Baguette", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4980) },
                    { 7, 1, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4982), "A delicious bacon sandwich.", false, 1.95m, "Bacon Sandwich", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4983) },
                    { 8, 4, new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4986), "A refreshing Coca Cola.", false, 1.2m, "Coca Cola", new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4987) }
                });

            migrationBuilder.InsertData(
                table: "NutritionalInformation",
                columns: new[] { "NutritionID", "Measurement", "NutrientID", "NutritionalValue", "ProductID" },
                values: new object[,]
                {
                    { 1, 100m, 1, 30m, 1 },
                    { 2, 100m, 2, 12m, 1 },
                    { 3, 100m, 3, 15m, 1 },
                    { 4, 100m, 4, 300m, 1 },
                    { 5, 100m, 5, 1256m, 1 },
                    { 6, 100m, 6, 3m, 1 },
                    { 7, 100m, 7, 1.5m, 1 },
                    { 8, 100m, 1, 28m, 2 },
                    { 9, 100m, 2, 10m, 2 },
                    { 10, 100m, 3, 14m, 2 },
                    { 11, 100m, 4, 280m, 2 },
                    { 12, 100m, 5, 1172m, 2 },
                    { 13, 100m, 6, 2.5m, 2 },
                    { 14, 100m, 7, 1.2m, 2 },
                    { 15, 100m, 1, 29m, 3 },
                    { 16, 100m, 2, 11m, 3 },
                    { 17, 100m, 3, 18m, 3 },
                    { 18, 100m, 4, 290m, 3 },
                    { 19, 100m, 5, 1215m, 3 },
                    { 20, 100m, 6, 3m, 3 },
                    { 21, 100m, 7, 1.7m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "NutritionalInformation",
                keyColumn: "NutritionID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nutrients",
                keyColumn: "NutrientID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);
        }
    }
}
