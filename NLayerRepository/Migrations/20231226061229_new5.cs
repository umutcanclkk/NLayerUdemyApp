using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerRepository.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Payments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 26, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 12, 24, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 12, 21, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 12, 25, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 12, 23, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 12, 22, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2023, 12, 20, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2023, 12, 19, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2023, 12, 18, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 12, 17, 9, 12, 29, 363, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 26, 9, 12, 29, 364, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 26, 9, 12, 29, 364, DateTimeKind.Local).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 26, 9, 12, 29, 364, DateTimeKind.Local).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 26, 9, 12, 29, 364, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 26, 9, 12, 29, 364, DateTimeKind.Local).AddTicks(814));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Payments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 21, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 12, 19, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 12, 16, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 12, 20, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 12, 18, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 12, 17, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2023, 12, 15, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2023, 12, 14, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2023, 12, 13, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(857));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 12, 12, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 14, 45, 0, 400, DateTimeKind.Local).AddTicks(4904));
        }
    }
}
