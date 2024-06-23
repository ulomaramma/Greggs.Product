using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greggs.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LocationSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversionRateToPounds = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Code", "ConversionRateToPounds", "Currency", "Name" },
                values: new object[] { 1, "EU", 1.11m, "EUR", "Europe" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4755), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4962), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4963) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4967), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4970), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4974), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4975) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4978), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4982), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4986), new DateTime(2024, 6, 21, 14, 31, 15, 291, DateTimeKind.Local).AddTicks(4987) });
        }
    }
}
