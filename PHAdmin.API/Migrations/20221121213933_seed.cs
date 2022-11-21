using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Floor", "Letter", "Status", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(678), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(690), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(691), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(692), 2, "A", "A", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
