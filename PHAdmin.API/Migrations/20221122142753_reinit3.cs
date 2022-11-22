using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class reinit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Letter = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "CONVERT([varchar](2),[Floor]) + '-' + [Letter]"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Floor", "Letter", "Status", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4695), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4710), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4711), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4712), 2, "A", "A", null, null },
                    { 5, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4713), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4714), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4748), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4749), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4750), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4751), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4756), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4757), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 11, 22, 9, 27, 53, 696, DateTimeKind.Local).AddTicks(4794), 3, "E", "A", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Copropietario" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
