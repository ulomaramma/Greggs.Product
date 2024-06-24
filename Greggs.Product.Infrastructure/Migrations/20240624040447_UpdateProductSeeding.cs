using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greggs.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConversionRateToPounds",
                table: "Locations",
                newName: "ExchangeRateToPounds");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2018, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2641) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2727) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2732), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2733) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2742) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2747) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2751), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2754) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2759) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExchangeRateToPounds",
                table: "Locations",
                newName: "ConversionRateToPounds");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1720), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1872), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1881), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1887), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1890) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1894), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1896) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1902), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1905) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1911), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1917), new DateTime(2024, 6, 23, 3, 35, 18, 997, DateTimeKind.Local).AddTicks(1919) });
        }
    }
}
