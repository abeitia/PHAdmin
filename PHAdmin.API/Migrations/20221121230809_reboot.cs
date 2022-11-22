using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class reboot : Migration
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

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Floor", "Letter", "Status", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4482), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4496), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4497), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 11, 21, 18, 8, 9, 666, DateTimeKind.Local).AddTicks(4497), 2, "A", "A", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
