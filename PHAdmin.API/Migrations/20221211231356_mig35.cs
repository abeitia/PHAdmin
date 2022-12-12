using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class mig35 : Migration
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "A")
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
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "A")
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "A")
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "A")
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "A")
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
                    { 1, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6787), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6812), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6813), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6815), 2, "A", "A", null, null },
                    { 5, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6820), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6821), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6822), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6826), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6828), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6829), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6830), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6831), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6832), 3, "E", "A", null, null },
                    { 14, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6863), 4, "A", "A", null, null },
                    { 15, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6864), 4, "B", "A", null, null },
                    { 16, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6865), 4, "C", "A", null, null },
                    { 17, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6866), 4, "D", "A", null, null },
                    { 18, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6870), 4, "E", "A", null, null },
                    { 19, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6872), 5, "A", "A", null, null },
                    { 20, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6873), 5, "B", "A", null, null },
                    { 21, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6874), 5, "C", "A", null, null },
                    { 22, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6875), 5, "D", "A", null, null },
                    { 23, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6876), 5, "E", "A", null, null },
                    { 24, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6877), 6, "A", "A", null, null },
                    { 25, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6878), 6, "B", "A", null, null },
                    { 26, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6879), 6, "C", "A", null, null },
                    { 27, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6880), 6, "D", "A", null, null },
                    { 28, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6881), 6, "E", "A", null, null },
                    { 29, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6883), 7, "A", "A", null, null },
                    { 30, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6884), 7, "B", "A", null, null },
                    { 31, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6885), 7, "C", "A", null, null },
                    { 32, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6886), 7, "D", "A", null, null },
                    { 33, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6887), 7, "E", "A", null, null },
                    { 34, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6889), 8, "A", "A", null, null },
                    { 35, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6890), 8, "B", "A", null, null },
                    { 36, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6891), 8, "C", "A", null, null },
                    { 37, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6892), 8, "D", "A", null, null },
                    { 38, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6893), 8, "E", "A", null, null },
                    { 39, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6894), 9, "A", "A", null, null },
                    { 40, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6895), 9, "B", "A", null, null },
                    { 41, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6896), 9, "C", "A", null, null },
                    { 42, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6898), 9, "D", "A", null, null },
                    { 43, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6899), 9, "E", "A", null, null },
                    { 44, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6900), 10, "A", "A", null, null },
                    { 45, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6904), 10, "B", "A", null, null },
                    { 46, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6905), 10, "C", "A", null, null },
                    { 47, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6906), 10, "D", "A", null, null },
                    { 48, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6907), 10, "E", "A", null, null },
                    { 49, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6908), 11, "A", "A", null, null },
                    { 50, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6909), 11, "B", "A", null, null },
                    { 51, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6911), 11, "C", "A", null, null },
                    { 52, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6912), 11, "D", "A", null, null },
                    { 53, null, new DateTime(2022, 12, 11, 18, 13, 56, 58, DateTimeKind.Local).AddTicks(6913), 11, "E", "A", null, null }
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
                    { 1, null, new DateTime(2022, 12, 11, 18, 13, 56, 64, DateTimeKind.Local).AddTicks(7316), "Roberto_Marin@hotmail.com", "380 265 553", "Roberto Marín", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "547.058.514", 2, "A", null, null },
                    { 2, null, new DateTime(2022, 12, 11, 18, 13, 56, 64, DateTimeKind.Local).AddTicks(9581), "Rafael72@gmail.com", "416 414 324", "Rafael Valle", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "507 180 448", 2, "A", null, null },
                    { 3, null, new DateTime(2022, 12, 11, 18, 13, 56, 65, DateTimeKind.Local).AddTicks(645), "Antonia.Roque@yahoo.com", "532 299 724", "Antonia Roque", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "517104893", 2, "A", null, null },
                    { 4, null, new DateTime(2022, 12, 11, 18, 13, 56, 65, DateTimeKind.Local).AddTicks(2858), "Carolina94@gmail.com", "390 318 301", "Carolina Barrios", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "507087274", 2, "A", null, null },
                    { 5, null, new DateTime(2022, 12, 11, 18, 13, 56, 65, DateTimeKind.Local).AddTicks(4491), "Miranda.Lebron@yahoo.com", "121 305 833", "Miranda Lebrón", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "535.880.910", 2, "A", null, null },
                    { 6, null, new DateTime(2022, 12, 11, 18, 13, 56, 65, DateTimeKind.Local).AddTicks(5372), "Vanessa6@nearbpo.com", "484 311 105", "Vanessa Flores", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5643-462-131", 2, "A", null, null },
                    { 7, null, new DateTime(2022, 12, 11, 18, 13, 56, 65, DateTimeKind.Local).AddTicks(6294), "Cristobal.Caraballo0@yahoo.com", "249 200 908", "Cristobal Caraballo", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5507-933-760", 2, "A", null, null },
                    { 8, null, new DateTime(2022, 12, 11, 18, 13, 56, 65, DateTimeKind.Local).AddTicks(7257), "Armando.Rico37@gmail.com", "330 535 857", "Armando Rico", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "568762837", 2, "A", null, null },
                    { 9, null, new DateTime(2022, 12, 11, 18, 13, 56, 65, DateTimeKind.Local).AddTicks(9088), "Berta.Bonilla@gmail.com", "964 994 115", "Berta Bonilla", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "548.312.139", 2, "A", null, null },
                    { 10, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(353), "AnaMaria_Perez92@yahoo.com", "064 927 593", "Ana María Pérez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "530646671", 2, "A", null, null },
                    { 11, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(1489), "Andrea_Guzman@nearbpo.com", "701 140 881", "Andrea Guzmán", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "506509230", 2, "A", null, null },
                    { 12, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(2556), "Luz.Lucio@hotmail.com", "639 257 245", "Luz Lucio", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "525104757", 2, "A", null, null },
                    { 13, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(3538), "Sara.Pagan93@nearbpo.com", "909 838 740", "Sara Pagan", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "508387201", 2, "A", null, null },
                    { 14, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(5205), "Lilia.Villegas@nearbpo.com", "040 981 102", "Lilia Villegas", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "581 692 295", 2, "A", null, null },
                    { 15, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(6638), "Daniela_Villa@gmail.com", "119 977 064", "Daniela Villa", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "569 454 475", 2, "A", null, null },
                    { 16, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(7818), "Eva.Zamora@gmail.com", "842 453 169", "Eva Zamora", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "532.851.970", 2, "A", null, null },
                    { 17, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(8839), "Luz.Garibay@nearbpo.com", "871 611 455", "Luz Garibay", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "547 839 582", 2, "A", null, null },
                    { 18, null, new DateTime(2022, 12, 11, 18, 13, 56, 66, DateTimeKind.Local).AddTicks(9711), "Emilia.Orosco4@corpfolder.com", "534 230 974", "Emilia Orosco", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "594.593.124", 2, "A", null, null },
                    { 19, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(549), "AnaLuisa19@gmail.com", "753 759 406", "Ana Luisa Chapa", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "597587845", 2, "A", null, null },
                    { 20, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(1280), "Natalia54@hotmail.com", "541 430 609", "Natalia Alanis", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "506 550 231", 2, "A", null, null },
                    { 21, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(2004), "Carolina_Garza@yahoo.com", "913 722 070", "Carolina Garza", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "564 473 467", 2, "A", null, null },
                    { 22, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(2720), "Sebastian67@yahoo.com", "198 248 940", "Sebastian Soria", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "590.358.299", 2, "A", null, null },
                    { 23, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(3380), "Hernan_Serrato57@nearbpo.com", "291 346 708", "Hernán Serrato", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "570311438", 2, "A", null, null },
                    { 24, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(4069), "Bernardo48@hotmail.com", "246 360 796", "Bernardo Alvarez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5836-329-428", 2, "A", null, null },
                    { 25, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(4771), "Elizabeth43@yahoo.com", "551 798 473", "Elizabeth Venegas", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5294-026-135", 2, "A", null, null },
                    { 26, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(5496), "Vicente_Hinojosa94@gmail.com", "158 443 986", "Vicente Hinojosa", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "505984070", 2, "A", null, null },
                    { 27, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(6202), "Melany.Casas50@hotmail.com", "017 456 799", "Melany Casas", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "509.738.684", 2, "A", null, null },
                    { 28, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(6962), "Micaela_Solis@hotmail.com", "363 675 687", "Micaela Solís", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "593.746.757", 2, "A", null, null },
                    { 29, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(7791), "Renata_Hernandes32@hotmail.com", "161 754 676", "Renata Hernandes", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5599-695-165", 2, "A", null, null },
                    { 30, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(8514), "David.Olivo@hotmail.com", "265 780 932", "David Olivo", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "563867311", 2, "A", null, null },
                    { 31, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(9259), "Eduardo_Escobar72@gmail.com", "758 289 201", "Eduardo Escobar", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5790-341-358", 2, "A", null, null },
                    { 32, null, new DateTime(2022, 12, 11, 18, 13, 56, 67, DateTimeKind.Local).AddTicks(9936), "Adela_Duran74@gmail.com", "467 864 260", "Adela Duran", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "573 973 968", 2, "A", null, null },
                    { 33, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(678), "Federico.Segovia@corpfolder.com", "580 767 564", "Federico Segovia", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "538.929.456", 2, "A", null, null },
                    { 34, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(1387), "Claudia.Vega@hotmail.com", "821 820 115", "Claudia Vega", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "516.344.037", 2, "A", null, null },
                    { 35, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(2069), "Isabela_Iglesias@yahoo.com", "542 974 704", "Isabela Iglesias", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "563 588 367", 2, "A", null, null },
                    { 36, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(2721), "Irene.Rivero18@corpfolder.com", "733 480 719", "Irene Rivero", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "579952249", 2, "A", null, null },
                    { 37, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(3340), "Iker43@nearbpo.com", "408 750 974", "Iker Mares", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "551543973", 2, "A", null, null },
                    { 38, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(4061), "Bernardo_Gonzales0@hotmail.com", "989 824 115", "Bernardo Gonzales", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "564 368 448", 2, "A", null, null },
                    { 39, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(4739), "Esteban_Vazquez@corpfolder.com", "429 479 892", "Esteban Vázquez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5912-204-818", 2, "A", null, null },
                    { 40, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(5434), "Diego_Espinosa66@hotmail.com", "993 242 684", "Diego Espinosa", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "538.457.492", 2, "A", null, null },
                    { 41, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(6220), "Emily.Samaniego@corpfolder.com", "329 455 679", "Emily Samaniego", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "528378071", 2, "A", null, null },
                    { 42, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(7088), "AnaMaria.Archuleta@hotmail.com", "636 468 647", "Ana María Archuleta", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "588 693 477", 2, "A", null, null },
                    { 43, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(8081), "Yolanda74@nearbpo.com", "111 971 347", "Yolanda Villarreal", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "568 457 257", 2, "A", null, null },
                    { 44, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(8893), "Rosario.Vargas@corpfolder.com", "512 021 890", "Rosario Vargas", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "503.126.368", 2, "A", null, null },
                    { 45, null, new DateTime(2022, 12, 11, 18, 13, 56, 68, DateTimeKind.Local).AddTicks(9677), "MariadeJesus_Mateo@gmail.com", "176 979 771", "María de Jesús Mateo", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5735-358-700", 2, "A", null, null },
                    { 46, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(495), "Emilio_Ocampo34@hotmail.com", "246 778 500", "Emilio Ocampo", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5911-304-250", 2, "A", null, null },
                    { 47, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(1352), "Luisa_Aranda@nearbpo.com", "761 189 901", "Luisa Aranda", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "589653502", 2, "A", null, null },
                    { 48, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(2093), "JoseEmilio.Arriaga78@corpfolder.com", "999 235 708", "José Emilio Arriaga", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "593 350 697", 2, "A", null, null },
                    { 49, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(2760), "Lucas.Barraza95@corpfolder.com", "909 828 378", "Lucas Barraza", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "564 898 611", 2, "A", null, null },
                    { 50, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(3443), "Mariana.Urena23@gmail.com", "977 786 235", "Mariana Ureña", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5567-249-279", 2, "A", null, null },
                    { 51, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(5169), "Diana.Campos@corpfolder.com", "369 894 522", "Diana Campos", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "556 715 643", 2, "A", null, null },
                    { 52, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(6761), "Felipe_Munoz@gmail.com", "579 576 497", "Felipe Muñoz", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5063-160-600", 2, "A", null, null },
                    { 53, null, new DateTime(2022, 12, 11, 18, 13, 56, 69, DateTimeKind.Local).AddTicks(7607), "Rodrigo.Rincon@gmail.com", "265 570 531", "Rodrigo Rincón", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5832-617-807", 2, "A", null, null }
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
