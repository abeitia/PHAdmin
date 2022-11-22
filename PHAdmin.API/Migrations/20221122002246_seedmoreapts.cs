using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class seedmoreapts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8594));

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Floor", "Letter", "Status", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8594), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8595), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8597), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8598), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8598), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8599), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8600), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8600), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 11, 21, 19, 22, 45, 967, DateTimeKind.Local).AddTicks(8601), 3, "E", "A", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4497));
        }
    }
}
