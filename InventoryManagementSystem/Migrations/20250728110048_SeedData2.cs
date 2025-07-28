using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("4ee2c2a9-13f5-4dac-8c37-5f353268e585"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5319fb65-b5d2-4433-9541-d8d153596aa1"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5d234ee2-3f43-44ba-8ab4-28abf3bb06a2"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("79c32404-d256-4433-ac5a-e6f146647782"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("883d01d6-5607-4ec1-92bd-78746889bef8"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b5d3496c-eff3-4fbe-b493-7295981e7bf9"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d97e2ba9-bcfa-4533-9251-5163b261036e"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("f2991aa2-bbef-4297-9bd9-a89904bec274"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("f7515dc8-23b0-4d69-afed-b61427cff1fc"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fda23346-bf1d-4570-b50f-4eb320270aa0"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Description", "Name", "Price", "Quantity", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Electronics", "15-inch laptop", "Laptop", 1200.00m, 10, 0 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Electronics", "Wireless mouse", "Mouse", 25.99m, 25, 0 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Electronics", "Mechanical keyboard", "Keyboard", 75.50m, 15, 0 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Electronics", "24-inch monitor", "Monitor", 150.00m, 8, 3 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Furniture", "Ergonomic chair", "Desk Chair", 200.00m, 5, 3 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Accessories", "Type-C USB cable", "USB Cable", 9.99m, 50, 0 },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Stationery", "A5 ruled notebook", "Notebook", 3.50m, 100, 0 },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Stationery", "Blue ink pen", "Pen", 1.00m, 200, 0 },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Furniture", "LED desk lamp", "Desk Lamp", 45.00m, 7, 0 },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Electronics", "1TB external hard drive", "External HDD", 80.00m, 12, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Description", "Name", "Price", "Quantity", "Status" },
                values: new object[,]
                {
                    { new Guid("4ee2c2a9-13f5-4dac-8c37-5f353268e585"), "Stationery", "A5 ruled notebook", "Notebook", 3.50m, 100, 0 },
                    { new Guid("5319fb65-b5d2-4433-9541-d8d153596aa1"), "Electronics", "15-inch laptop", "Laptop", 1200.00m, 10, 0 },
                    { new Guid("5d234ee2-3f43-44ba-8ab4-28abf3bb06a2"), "Stationery", "Blue ink pen", "Pen", 1.00m, 200, 0 },
                    { new Guid("79c32404-d256-4433-ac5a-e6f146647782"), "Electronics", "Wireless mouse", "Mouse", 25.99m, 25, 0 },
                    { new Guid("883d01d6-5607-4ec1-92bd-78746889bef8"), "Furniture", "Ergonomic chair", "Desk Chair", 200.00m, 5, 3 },
                    { new Guid("b5d3496c-eff3-4fbe-b493-7295981e7bf9"), "Accessories", "Type-C USB cable", "USB Cable", 9.99m, 50, 0 },
                    { new Guid("d97e2ba9-bcfa-4533-9251-5163b261036e"), "Electronics", "1TB external hard drive", "External HDD", 80.00m, 12, 0 },
                    { new Guid("f2991aa2-bbef-4297-9bd9-a89904bec274"), "Furniture", "LED desk lamp", "Desk Lamp", 45.00m, 7, 0 },
                    { new Guid("f7515dc8-23b0-4d69-afed-b61427cff1fc"), "Electronics", "Mechanical keyboard", "Keyboard", 75.50m, 15, 0 },
                    { new Guid("fda23346-bf1d-4570-b50f-4eb320270aa0"), "Electronics", "24-inch monitor", "Monitor", 150.00m, 8, 3 }
                });
        }
    }
}
