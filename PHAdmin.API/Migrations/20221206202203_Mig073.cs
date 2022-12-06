using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class Mig073 : Migration
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
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateValue = table.Column<DateTime>(type: "Date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debts_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Floor", "Letter", "Status", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8031), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8058), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8059), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8061), 2, "A", "A", null, null },
                    { 5, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8062), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8063), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8065), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8068), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8070), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8071), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8072), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8073), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8075), 3, "E", "A", null, null },
                    { 14, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8076), 4, "A", "A", null, null },
                    { 15, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8077), 4, "B", "A", null, null },
                    { 16, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8078), 4, "C", "A", null, null },
                    { 17, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8080), 4, "D", "A", null, null },
                    { 18, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8081), 4, "E", "A", null, null },
                    { 19, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8083), 5, "A", "A", null, null },
                    { 20, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8084), 5, "B", "A", null, null },
                    { 21, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8085), 5, "C", "A", null, null },
                    { 22, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8088), 5, "D", "A", null, null },
                    { 23, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8089), 5, "E", "A", null, null },
                    { 24, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8090), 6, "A", "A", null, null },
                    { 25, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8092), 6, "B", "A", null, null },
                    { 26, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8094), 6, "C", "A", null, null },
                    { 27, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8095), 6, "D", "A", null, null },
                    { 28, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8096), 6, "E", "A", null, null },
                    { 29, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8097), 7, "A", "A", null, null },
                    { 30, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8099), 7, "B", "A", null, null },
                    { 31, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8100), 7, "C", "A", null, null },
                    { 32, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8101), 7, "D", "A", null, null },
                    { 33, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8102), 7, "E", "A", null, null },
                    { 34, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8104), 8, "A", "A", null, null },
                    { 35, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8106), 8, "B", "A", null, null },
                    { 36, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8107), 8, "C", "A", null, null },
                    { 37, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8108), 8, "D", "A", null, null },
                    { 38, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8109), 8, "E", "A", null, null },
                    { 39, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8110), 9, "A", "A", null, null },
                    { 40, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8111), 9, "B", "A", null, null },
                    { 41, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8113), 9, "C", "A", null, null },
                    { 42, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8114), 9, "D", "A", null, null },
                    { 43, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8115), 9, "E", "A", null, null },
                    { 44, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8116), 10, "A", "A", null, null },
                    { 45, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8117), 10, "B", "A", null, null },
                    { 46, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8118), 10, "C", "A", null, null },
                    { 47, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8120), 10, "D", "A", null, null },
                    { 48, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8152), 10, "E", "A", null, null },
                    { 49, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8153), 11, "A", "A", null, null },
                    { 50, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8154), 11, "B", "A", null, null },
                    { 51, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8157), 11, "C", "A", null, null },
                    { 52, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8158), 11, "D", "A", null, null },
                    { 53, null, new DateTime(2022, 12, 6, 15, 22, 2, 900, DateTimeKind.Local).AddTicks(8160), 11, "E", "A", null, null }
                });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "ExpenseName" },
                values: new object[,]
                {
                    { 1, "Artículos de limpieza" },
                    { 2, "Caja de Seguro Social" },
                    { 3, "Caja menuda" },
                    { 4, "Cargos bancarios" },
                    { 5, "Cerrajería" },
                    { 6, "Conserje" },
                    { 7, "Devolución de reserva" },
                    { 8, "Fotocopias" },
                    { 9, "Fumigación" },
                    { 10, "Gastos legales" },
                    { 11, "Mantenimiento de A/A." },
                    { 12, "Mantenimiento de ascensores" },
                    { 13, "Mantenimiento de bomba de agua" },
                    { 14, "Mantenimiento de planta eléctrica" },
                    { 15, "Mantenimiento de puertas mecánicas" },
                    { 16, "Portería" },
                    { 17, "Reembolso" },
                    { 18, "Servicio de administración" },
                    { 19, "Servicio de agua" },
                    { 20, "Servicio de electricidad" },
                    { 21, "Servicio de gas" }
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "DateValue", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Año Nuevo" },
                    { 2, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Día de los Martíres" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentName" },
                values: new object[,]
                {
                    { 1, "Cuota Ordinaria" },
                    { 2, "Cuota Extraordinaria" },
                    { 3, "Reserva de área común" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Copropietario" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Email", "Identification", "Name", "Password", "Phone", "RoleId", "Status", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 12, 6, 15, 22, 2, 903, DateTimeKind.Local).AddTicks(9683), "Blanca_Quezada53@gmail.com", "824 898 449", "Blanca Quezada", "1234", "5026-448-753", 2, "A", null, null },
                    { 2, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(1211), "AngelGabriel66@hotmail.com", "818 070 435", "Ángel Gabriel León", "1234", "529 637 586", 2, "A", null, null },
                    { 3, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(2289), "Armando_Casas@nearbpo.com", "219 001 278", "Armando Casas", "1234", "5660-014-629", 2, "A", null, null },
                    { 4, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(3083), "Paola_Olivera@corpfolder.com", "386 773 618", "Paola Olivera", "1234", "5595-785-954", 2, "A", null, null },
                    { 5, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(3947), "Susana.Kardachesoto@corpfolder.com", "688 747 104", "Susana Kardache soto", "1234", "599.447.551", 2, "A", null, null },
                    { 6, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(4744), "Isabel92@nearbpo.com", "390 411 411", "Isabel Sandoval", "1234", "579.641.983", 2, "A", null, null },
                    { 7, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(5763), "Isaias_Centeno69@gmail.com", "358 810 687", "Isaias Centeno", "1234", "578375061", 2, "A", null, null },
                    { 8, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(6586), "Conchita66@corpfolder.com", "446 858 979", "Conchita Gaona", "1234", "571.496.079", 2, "A", null, null },
                    { 9, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(7306), "Blanca_Orosco@yahoo.com", "836 825 471", "Blanca Orosco", "1234", "539.254.652", 2, "A", null, null },
                    { 10, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(8108), "Leonardo_Nunez59@gmail.com", "714 800 521", "Leonardo Núñez", "1234", "541 240 249", 2, "A", null, null },
                    { 11, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(8942), "FernandoJavier_Escalante@yahoo.com", "021 255 955", "Fernando Javier Escalante", "1234", "569424938", 2, "A", null, null },
                    { 12, null, new DateTime(2022, 12, 6, 15, 22, 2, 904, DateTimeKind.Local).AddTicks(9747), "Amalia_Fuentes@yahoo.com", "475 627 949", "Amalia Fuentes", "1234", "526 736 502", 2, "A", null, null },
                    { 13, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(526), "Brayan.Rosario8@gmail.com", "875 193 823", "Brayan Rosario", "1234", "5243-922-479", 2, "A", null, null },
                    { 14, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(1516), "Octavio2@corpfolder.com", "927 824 797", "Octavio Escamilla", "1234", "585 307 980", 2, "A", null, null },
                    { 15, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(2419), "Angela_Rubio@nearbpo.com", "144 533 742", "Ángela Rubio", "1234", "512367606", 2, "A", null, null },
                    { 16, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(3216), "Francisco31@corpfolder.com", "844 493 270", "Francisco Urrutia", "1234", "514.567.325", 2, "A", null, null },
                    { 17, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(4040), "Isaias_Sotelo@yahoo.com", "774 889 976", "Isaias Sotelo", "1234", "543413811", 2, "A", null, null },
                    { 18, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(4787), "MariadelCarmen.Navarrete@yahoo.com", "581 218 450", "María del Carmen Navarrete", "1234", "527 847 562", 2, "A", null, null },
                    { 19, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(5521), "Marilu_Tamayo10@corpfolder.com", "723 033 536", "Marilu Tamayo", "1234", "5062-921-243", 2, "A", null, null },
                    { 20, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(6379), "Nicole.Bustos9@corpfolder.com", "982 919 185", "Nicole Bustos", "1234", "505896818", 2, "A", null, null },
                    { 21, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(7224), "Norma_Rascon@yahoo.com", "513 834 101", "Norma Rascón", "1234", "526200302", 2, "A", null, null },
                    { 22, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(7918), "Gonzalo49@corpfolder.com", "384 523 684", "Gonzalo Véliz", "1234", "5172-822-390", 2, "A", null, null },
                    { 23, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(8733), "Abril28@nearbpo.com", "389 251 992", "Abril Mercado", "1234", "5117-264-321", 2, "A", null, null },
                    { 24, null, new DateTime(2022, 12, 6, 15, 22, 2, 905, DateTimeKind.Local).AddTicks(9492), "Reina.Vallejo@yahoo.com", "825 783 897", "Reina Vallejo", "1234", "520.659.413", 2, "A", null, null },
                    { 25, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(192), "Juana55@nearbpo.com", "415 376 318", "Juana Rivero", "1234", "544.766.403", 2, "A", null, null },
                    { 26, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(932), "Esteban.Blanco46@yahoo.com", "608 988 077", "Esteban Blanco", "1234", "5513-312-709", 2, "A", null, null },
                    { 27, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(1695), "MiguelAngel1@hotmail.com", "046 104 055", "Miguel Ángel Rocha", "1234", "572730347", 2, "A", null, null },
                    { 28, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(2507), "LuisFernando_Zamarripa64@yahoo.com", "251 801 478", "Luis Fernando Zamarripa", "1234", "569008256", 2, "A", null, null },
                    { 29, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(3269), "Esteban93@gmail.com", "573 079 688", "Esteban Tafoya", "1234", "554 664 230", 2, "A", null, null },
                    { 30, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(4024), "Daniel16@gmail.com", "578 856 387", "Daniel Centeno", "1234", "561868281", 2, "A", null, null },
                    { 31, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(4798), "Cecilia28@nearbpo.com", "503 190 050", "Cecilia Campos", "1234", "533.476.753", 2, "A", null, null },
                    { 32, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(5524), "Olivia_Abrego34@gmail.com", "626 186 415", "Olivia Abrego", "1234", "581 900 106", 2, "A", null, null },
                    { 33, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(6275), "Estefania.Dominquez80@gmail.com", "547 953 117", "Estefanía Domínquez", "1234", "559 409 326", 2, "A", null, null },
                    { 34, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(6980), "Saul.Tamez77@corpfolder.com", "234 625 804", "Saúl Tamez", "1234", "550.412.124", 2, "A", null, null },
                    { 35, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(7720), "Maria.Pabon@nearbpo.com", "256 143 637", "María Pabón", "1234", "505 488 456", 2, "A", null, null },
                    { 36, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(8427), "Alan_Cardenas@corpfolder.com", "327 297 834", "Alan Cardenas", "1234", "554 210 256", 2, "A", null, null },
                    { 37, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(9176), "Susana.Adorno37@nearbpo.com", "799 839 436", "Susana Adorno", "1234", "557.844.410", 2, "A", null, null },
                    { 38, null, new DateTime(2022, 12, 6, 15, 22, 2, 906, DateTimeKind.Local).AddTicks(9909), "Elisa_Alarcon81@nearbpo.com", "469 313 787", "Elisa Alarcón", "1234", "531319571", 2, "A", null, null },
                    { 39, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(659), "Claudio_Holguin@nearbpo.com", "338 609 126", "Claudio Holguín", "1234", "524.317.922", 2, "A", null, null },
                    { 40, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(1411), "Clara86@yahoo.com", "297 135 766", "Clara Alfaro", "1234", "571 008 749", 2, "A", null, null },
                    { 41, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(2172), "JoseEduardo52@hotmail.com", "170 565 584", "José Eduardo Rojas", "1234", "500428596", 2, "A", null, null },
                    { 42, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(2895), "Sara.Trujillo@gmail.com", "347 878 217", "Sara Trujillo", "1234", "575 400 440", 2, "A", null, null },
                    { 43, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(3638), "Ricardo51@nearbpo.com", "393 825 849", "Ricardo Valdivia", "1234", "580 434 146", 2, "A", null, null },
                    { 44, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(4344), "Enrique.Delapaz@corpfolder.com", "311 679 732", "Enrique Delapaz", "1234", "508.440.964", 2, "A", null, null },
                    { 45, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(5103), "Beatriz.Longoria14@yahoo.com", "508 928 215", "Beatriz Longoria", "1234", "543 432 351", 2, "A", null, null },
                    { 46, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(5860), "Conchita_Villalpando80@hotmail.com", "753 389 212", "Conchita Villalpando", "1234", "5665-589-728", 2, "A", null, null },
                    { 47, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(6550), "Miranda.Chacon17@nearbpo.com", "312 889 231", "Miranda Chacón", "1234", "591599790", 2, "A", null, null },
                    { 48, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(7280), "Anita88@yahoo.com", "485 341 119", "Anita Caballero", "1234", "5417-776-811", 2, "A", null, null },
                    { 49, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(8033), "MariaJose_Arguello83@nearbpo.com", "006 107 080", "María José Arguello", "1234", "501.799.008", 2, "A", null, null },
                    { 50, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(8735), "Esteban_Salas7@corpfolder.com", "158 119 552", "Esteban Salas", "1234", "562398854", 2, "A", null, null },
                    { 51, null, new DateTime(2022, 12, 6, 15, 22, 2, 907, DateTimeKind.Local).AddTicks(9486), "MariaTeresa.Galvan@yahoo.com", "627 316 607", "María Teresa Galván", "1234", "513386339", 2, "A", null, null },
                    { 52, null, new DateTime(2022, 12, 6, 15, 22, 2, 908, DateTimeKind.Local).AddTicks(217), "Santiago_Pineda11@hotmail.com", "967 666 967", "Santiago Pineda", "1234", "536.611.641", 2, "A", null, null },
                    { 53, null, new DateTime(2022, 12, 6, 15, 22, 2, 908, DateTimeKind.Local).AddTicks(908), "Debora_Carmona@corpfolder.com", "349 682 898", "Débora Carmona", "1234", "510.370.668", 2, "A", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debts_ApartmentId",
                table: "Debts",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_PaymentTypeId",
                table: "Debts",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
