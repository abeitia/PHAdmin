using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class uno : Migration
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
                    { 1, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(666), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(688), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(689), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(690), 2, "A", "A", null, null },
                    { 5, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(692), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(693), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(694), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(696), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(697), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(698), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(699), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(700), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 12, 6, 9, 25, 10, 996, DateTimeKind.Local).AddTicks(702), 3, "E", "A", null, null }
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
                    { 1, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(2497), "Paulina.Korta@hotmail.com", "393 711 122", "Paulina Korta", "1234", "549.670.810", 2, "A", null, null },
                    { 2, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(3526), "Hugo75@nearbpo.com", "170 248 900", "Hugo Rodarte", "1234", "5773-486-850", 2, "A", null, null },
                    { 3, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(4167), "AnaSofia26@yahoo.com", "067 285 411", "Ana Sofía Ibarra", "1234", "5874-931-526", 2, "A", null, null },
                    { 4, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(4803), "Alexa_Espinal@corpfolder.com", "908 452 576", "Alexa Espinal", "1234", "549 616 446", 2, "A", null, null },
                    { 5, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(5402), "Dolores_Maya91@gmail.com", "645 214 552", "Dolores Maya", "1234", "5744-647-086", 2, "A", null, null },
                    { 6, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(5996), "Lorena.Kanaria20@gmail.com", "280 475 054", "Lorena Kanaria", "1234", "515319241", 2, "A", null, null },
                    { 7, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(6624), "AngelGabriel99@yahoo.com", "077 337 962", "Ángel Gabriel Peralta", "1234", "599 341 869", 2, "A", null, null },
                    { 8, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(7267), "Nicole8@yahoo.com", "201 586 120", "Nicole Gaitán", "1234", "513.620.421", 2, "A", null, null },
                    { 9, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(7881), "Natalia.Espinal@corpfolder.com", "863 240 453", "Natalia Espinal", "1234", "545142498", 2, "A", null, null },
                    { 10, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(8461), "LuisFernando76@gmail.com", "184 012 169", "Luis Fernando Verdugo", "1234", "5692-296-824", 2, "A", null, null },
                    { 11, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(9065), "Israel.Briones88@hotmail.com", "153 595 889", "Israel Briones", "1234", "5934-355-899", 2, "A", null, null },
                    { 12, null, new DateTime(2022, 12, 6, 9, 25, 10, 998, DateTimeKind.Local).AddTicks(9629), "Rafael_Pantoja@yahoo.com", "574 073 532", "Rafael Pantoja", "1234", "522.032.834", 2, "A", null, null },
                    { 13, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(247), "AngelGabriel73@hotmail.com", "499 399 517", "Ángel Gabriel Gallegos", "1234", "526398360", 2, "A", null, null },
                    { 14, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(891), "Emiliano.Sedillo4@gmail.com", "709 991 921", "Emiliano Sedillo", "1234", "557.940.851", 2, "A", null, null },
                    { 15, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(1514), "Martin.Segovia@yahoo.com", "198 404 782", "Martín Segovia", "1234", "561.419.772", 2, "A", null, null },
                    { 16, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(2078), "Mayte.Pelayo90@gmail.com", "842 066 656", "Mayte Pelayo", "1234", "561.896.509", 2, "A", null, null },
                    { 17, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(2707), "Uriel_Rios@gmail.com", "575 905 062", "Uriel Ríos", "1234", "589 671 770", 2, "A", null, null },
                    { 18, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(3312), "Jorge21@hotmail.com", "619 684 046", "Jorge Saldivar", "1234", "581912058", 2, "A", null, null },
                    { 19, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(3870), "Eloisa_Madrigal@nearbpo.com", "561 193 442", "Eloisa Madrigal", "1234", "5005-431-835", 2, "A", null, null },
                    { 20, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(4516), "Lucas64@nearbpo.com", "124 082 215", "Lucas Alonzo", "1234", "500 731 980", 2, "A", null, null },
                    { 21, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(5069), "Jacobo.Luevano@nearbpo.com", "541 197 141", "Jacobo Luevano", "1234", "526.640.000", 2, "A", null, null },
                    { 22, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(5647), "Emiliano_Collado@yahoo.com", "275 430 148", "Emiliano Collado", "1234", "5568-786-240", 2, "A", null, null },
                    { 23, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(6230), "Paola_Jaime@nearbpo.com", "013 483 326", "Paola Jaime", "1234", "509.767.098", 2, "A", null, null },
                    { 24, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(6803), "Sancho66@gmail.com", "207 300 468", "Sancho Ortiz", "1234", "533467317", 2, "A", null, null },
                    { 25, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(7389), "Ricardo_Tello@nearbpo.com", "180 403 248", "Ricardo Tello", "1234", "524978221", 2, "A", null, null },
                    { 26, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(8136), "Marisol.Montenegro21@yahoo.com", "279 660 690", "Marisol Montenegro", "1234", "5460-398-158", 2, "A", null, null },
                    { 27, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(8749), "Lucas_Navarrete@yahoo.com", "832 220 081", "Lucas Navarrete", "1234", "543866174", 2, "A", null, null },
                    { 28, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(9297), "Teodoro_Trejo@hotmail.com", "524 980 190", "Teodoro Trejo", "1234", "5499-671-662", 2, "A", null, null },
                    { 29, null, new DateTime(2022, 12, 6, 9, 25, 10, 999, DateTimeKind.Local).AddTicks(9874), "Ernesto_Vargas@gmail.com", "313 250 797", "Ernesto Vargas", "1234", "587 128 467", 2, "A", null, null },
                    { 30, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(554), "Fatima18@corpfolder.com", "241 831 882", "Fatima Arellano", "1234", "528023606", 2, "A", null, null },
                    { 31, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(1152), "Alfonso.Murillo11@gmail.com", "905 288 254", "Alfonso Murillo", "1234", "583938092", 2, "A", null, null },
                    { 32, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(1725), "Roberto73@hotmail.com", "267 674 679", "Roberto Rojas", "1234", "557 474 340", 2, "A", null, null },
                    { 33, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(2350), "Salvador_Gastelum@nearbpo.com", "849 427 752", "Salvador Gastélum", "1234", "546 662 377", 2, "A", null, null },
                    { 34, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(3010), "Patricio.Vargas3@corpfolder.com", "542 259 676", "Patricio Vargas", "1234", "595 903 195", 2, "A", null, null },
                    { 35, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(3611), "Luz97@gmail.com", "370 401 606", "Luz Palomo", "1234", "5486-002-529", 2, "A", null, null },
                    { 36, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(4236), "Luisa43@yahoo.com", "815 435 367", "Luisa Armendáriz", "1234", "584158865", 2, "A", null, null },
                    { 37, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(4856), "Francisca.Posada@hotmail.com", "823 025 119", "Francisca Posada", "1234", "5765-769-427", 2, "A", null, null },
                    { 38, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(5450), "MariaFernanda_Haro@gmail.com", "411 627 706", "María Fernanda Haro", "1234", "530906451", 2, "A", null, null },
                    { 39, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(6018), "Guillermina15@yahoo.com", "593 594 245", "Guillermina Iglesias", "1234", "5279-164-445", 2, "A", null, null },
                    { 40, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(6732), "Rosa.Velez71@yahoo.com", "589 993 179", "Rosa Vélez", "1234", "501 005 041", 2, "A", null, null },
                    { 41, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(7315), "Lucas.Cavazos39@yahoo.com", "066 807 868", "Lucas Cavazos", "1234", "5273-011-427", 2, "A", null, null },
                    { 42, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(7861), "Elena_Holguin10@gmail.com", "149 413 254", "Elena Holguín", "1234", "504983024", 2, "A", null, null },
                    { 43, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(8491), "JoseMiguel_Sandoval91@nearbpo.com", "441 534 567", "José Miguel Sandoval", "1234", "517.764.727", 2, "A", null, null },
                    { 44, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(9066), "Mateo94@gmail.com", "215 898 735", "Mateo Rivero", "1234", "564.459.716", 2, "A", null, null },
                    { 45, null, new DateTime(2022, 12, 6, 9, 25, 11, 0, DateTimeKind.Local).AddTicks(9624), "Arturo_Delarosa@nearbpo.com", "220 624 043", "Arturo Delarosa", "1234", "533 194 370", 2, "A", null, null },
                    { 46, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(225), "Gael_Pulido@hotmail.com", "127 512 796", "Gael Pulido", "1234", "570 690 005", 2, "A", null, null },
                    { 47, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(902), "Ximena26@yahoo.com", "665 230 405", "Ximena Miranda", "1234", "534.602.840", 2, "A", null, null },
                    { 48, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(1460), "JoseMaria.Gollum@nearbpo.com", "562 480 764", "José María Gollum", "1234", "5035-581-918", 2, "A", null, null },
                    { 49, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(2074), "Amalia_Urena4@yahoo.com", "398 777 342", "Amalia Ureña", "1234", "5604-925-675", 2, "A", null, null },
                    { 50, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(2693), "Luis72@gmail.com", "288 584 089", "Luis Gil", "1234", "5778-436-169", 2, "A", null, null },
                    { 51, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(3251), "Felipe.Ochoa@corpfolder.com", "418 404 570", "Felipe Ochoa", "1234", "517 199 084", 2, "A", null, null },
                    { 52, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(3848), "Beatriz59@yahoo.com", "930 579 529", "Beatriz Farías", "1234", "5759-773-420", 2, "A", null, null },
                    { 53, null, new DateTime(2022, 12, 6, 9, 25, 11, 1, DateTimeKind.Local).AddTicks(4498), "Victor.Armenta71@corpfolder.com", "450 460 068", "Víctor Armenta", "1234", "5310-142-013", 2, "A", null, null }
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
