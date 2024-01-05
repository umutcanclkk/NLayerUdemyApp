using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerRepository.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 21, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 12, 19, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 12, 16, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 12, 20, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6475));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 12, 18, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 12, 17, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2023, 12, 15, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2023, 12, 14, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2023, 12, 13, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 12, 12, 11, 55, 59, 43, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 11, 55, 59, 44, DateTimeKind.Local).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 11, 55, 59, 44, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 11, 55, 59, 44, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 11, 55, 59, 44, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 11, 55, 59, 44, DateTimeKind.Local).AddTicks(215));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 12, 13, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 12, 11, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 12, 8, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 12, 12, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 12, 10, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 12, 9, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2023, 12, 7, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2023, 12, 6, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2023, 12, 5, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 12, 4, 15, 16, 57, 216, DateTimeKind.Local).AddTicks(6251));

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
    }
}
