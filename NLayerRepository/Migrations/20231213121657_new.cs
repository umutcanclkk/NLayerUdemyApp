using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerRepository.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    E_Mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "E_Mail", "Name", "PhoneNumber", "SurName" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", 123456789, "Doe" },
                    { 2, "jane.smith@example.com", "Jane", 987654321, "Smith" },
                    { 3, "alice.johnson@example.com", "Alice", 555555555, "Johnson" },
                    { 4, "bob.williams@example.com", "Bob", 777777777, "Williams" },
                    { 5, "eve.taylor@example.com", "Eve", 999999999, "Taylor" },
                    { 6, "michael.johnson@example.com", "Michael", 111111111, "Johnson" },
                    { 7, "emily.davis@example.com", "Emily", 222222222, "Davis" },
                    { 8, "daniel.brown@example.com", "Daniel", 333333333, "Brown" },
                    { 9, "olivia.miller@example.com", "Olivia", 444444444, "Miller" },
                    { 10, "william.clark@example.com", "William", 555555555, "Clark" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Date", "PaymentMethod", "TransactionId" },
                values: new object[,]
                {
                    { 1, 100.50m, new DateTime(2023, 12, 13, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6228), "Kredi Kartı", "ABC123" },
                    { 2, 50.75m, new DateTime(2023, 12, 11, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6240), "Nakit", "XYZ789" },
                    { 3, 200.00m, new DateTime(2023, 12, 8, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6244), "Havale", "DEF456" },
                    { 4, 75.25m, new DateTime(2023, 12, 12, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6245), "Kripto Para", "GHI789" },
                    { 5, 120.90m, new DateTime(2023, 12, 10, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6246), "Çek", "JKL012" },
                    { 6, 85.60m, new DateTime(2023, 12, 9, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6247), "Banka Kartı", "MNO345" },
                    { 7, 150.25m, new DateTime(2023, 12, 7, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6248), "EFT", "PQR678" },
                    { 8, 60.30m, new DateTime(2023, 12, 6, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6249), "Sanal Cüzdan", "STU901" },
                    { 9, 40.15m, new DateTime(2023, 12, 5, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6250), "Mobil Ödeme", "VWX234" },
                    { 10, 110.75m, new DateTime(2023, 12, 4, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6251), "Fatura Ödeme", "YZA567" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 15, 16, 57, 217, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 15, 16, 57, 217, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 15, 16, 57, 217, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 15, 16, 57, 217, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 15, 16, 57, 217, DateTimeKind.Local).AddTicks(784));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 17, 10, 59, 209, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 17, 10, 59, 209, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 17, 10, 59, 209, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 17, 10, 59, 209, DateTimeKind.Local).AddTicks(8027));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 17, 10, 59, 209, DateTimeKind.Local).AddTicks(8029));
        }
    }
}
