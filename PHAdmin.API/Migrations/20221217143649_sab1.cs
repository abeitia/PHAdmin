using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class sab1 : Migration
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
                    Comments = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
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
                    Comments = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
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
                    Comments = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
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
                    { 1, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3021), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3055), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3058), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3060), 2, "A", "A", null, null },
                    { 5, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3066), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3068), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3070), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3073), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3076), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3078), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3079), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3081), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3083), 3, "E", "A", null, null },
                    { 14, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3085), 4, "A", "A", null, null },
                    { 15, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3088), 4, "B", "A", null, null },
                    { 16, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3090), 4, "C", "A", null, null },
                    { 17, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3092), 4, "D", "A", null, null },
                    { 18, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3094), 4, "E", "A", null, null },
                    { 19, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3096), 5, "A", "A", null, null },
                    { 20, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3097), 5, "B", "A", null, null },
                    { 21, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3099), 5, "C", "A", null, null },
                    { 22, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3101), 5, "D", "A", null, null },
                    { 23, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3103), 5, "E", "A", null, null },
                    { 24, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3105), 6, "A", "A", null, null },
                    { 25, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3107), 6, "B", "A", null, null },
                    { 26, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3109), 6, "C", "A", null, null },
                    { 27, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3111), 6, "D", "A", null, null },
                    { 28, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3112), 6, "E", "A", null, null },
                    { 29, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3115), 7, "A", "A", null, null },
                    { 30, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3117), 7, "B", "A", null, null },
                    { 31, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3119), 7, "C", "A", null, null },
                    { 32, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3121), 7, "D", "A", null, null },
                    { 33, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3123), 7, "E", "A", null, null },
                    { 34, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3125), 8, "A", "A", null, null },
                    { 35, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3126), 8, "B", "A", null, null },
                    { 36, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3128), 8, "C", "A", null, null },
                    { 37, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3130), 8, "D", "A", null, null },
                    { 38, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3132), 8, "E", "A", null, null },
                    { 39, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3134), 9, "A", "A", null, null },
                    { 40, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3136), 9, "B", "A", null, null },
                    { 41, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3138), 9, "C", "A", null, null },
                    { 42, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3139), 9, "D", "A", null, null },
                    { 43, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3141), 9, "E", "A", null, null },
                    { 44, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3143), 10, "A", "A", null, null },
                    { 45, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3145), 10, "B", "A", null, null },
                    { 46, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3147), 10, "C", "A", null, null },
                    { 47, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3191), 10, "D", "A", null, null },
                    { 48, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3194), 10, "E", "A", null, null },
                    { 49, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3196), 11, "A", "A", null, null },
                    { 50, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3199), 11, "B", "A", null, null },
                    { 51, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3201), 11, "C", "A", null, null },
                    { 52, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3203), 11, "D", "A", null, null },
                    { 53, null, new DateTime(2022, 12, 17, 9, 36, 48, 907, DateTimeKind.Local).AddTicks(3205), 11, "E", "A", null, null }
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
                    { 1, null, new DateTime(2022, 12, 17, 9, 36, 48, 911, DateTimeKind.Local).AddTicks(5662), "Jennifer61@yahoo.com", "455 460 667", "Jennifer Cordero", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "544059567", 2, "A", null, null },
                    { 2, null, new DateTime(2022, 12, 17, 9, 36, 48, 911, DateTimeKind.Local).AddTicks(8148), "Esmeralda_Davila@yahoo.com", "897 924 320", "Esmeralda Dávila", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "556233410", 2, "A", null, null },
                    { 3, null, new DateTime(2022, 12, 17, 9, 36, 48, 911, DateTimeKind.Local).AddTicks(9791), "Emily52@hotmail.com", "847 306 396", "Emily Valverde", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5662-167-657", 2, "A", null, null },
                    { 4, null, new DateTime(2022, 12, 17, 9, 36, 48, 912, DateTimeKind.Local).AddTicks(1536), "Barbara_Estevez@hotmail.com", "545 875 510", "Barbara Estévez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "545 250 055", 2, "A", null, null },
                    { 5, null, new DateTime(2022, 12, 17, 9, 36, 48, 912, DateTimeKind.Local).AddTicks(3171), "Marilu_Mejia84@yahoo.com", "117 348 581", "Marilu Mejía", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "504 279 377", 2, "A", null, null },
                    { 6, null, new DateTime(2022, 12, 17, 9, 36, 48, 912, DateTimeKind.Local).AddTicks(4766), "Martin5@nearbpo.com", "836 118 547", "Martín Domínguez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5007-995-894", 2, "A", null, null },
                    { 7, null, new DateTime(2022, 12, 17, 9, 36, 48, 912, DateTimeKind.Local).AddTicks(6290), "Blanca12@hotmail.com", "661 240 960", "Blanca Pichardo", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5472-648-731", 2, "A", null, null },
                    { 8, null, new DateTime(2022, 12, 17, 9, 36, 48, 912, DateTimeKind.Local).AddTicks(7884), "Armando_Cardenas28@yahoo.com", "213 710 411", "Armando Cardenas", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "528536955", 2, "A", null, null },
                    { 9, null, new DateTime(2022, 12, 17, 9, 36, 48, 912, DateTimeKind.Local).AddTicks(9435), "Paulina15@gmail.com", "302 781 612", "Paulina Kara", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "566049734", 2, "A", null, null },
                    { 10, null, new DateTime(2022, 12, 17, 9, 36, 48, 913, DateTimeKind.Local).AddTicks(1068), "Gael.Meraz45@corpfolder.com", "698 712 544", "Gael Meraz", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "512 554 828", 2, "A", null, null },
                    { 11, null, new DateTime(2022, 12, 17, 9, 36, 48, 913, DateTimeKind.Local).AddTicks(2609), "Vanessa.Jimenez80@corpfolder.com", "312 811 508", "Vanessa Jiménez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5717-322-418", 2, "A", null, null },
                    { 12, null, new DateTime(2022, 12, 17, 9, 36, 48, 913, DateTimeKind.Local).AddTicks(4054), "Yamileth_Limon@gmail.com", "345 921 142", "Yamileth Limón", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "590.851.652", 2, "A", null, null },
                    { 13, null, new DateTime(2022, 12, 17, 9, 36, 48, 913, DateTimeKind.Local).AddTicks(5515), "Julia.Orozco31@yahoo.com", "240 137 513", "Julia Orozco", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5807-992-251", 2, "A", null, null },
                    { 14, null, new DateTime(2022, 12, 17, 9, 36, 48, 913, DateTimeKind.Local).AddTicks(7008), "Lucas.Garcia32@hotmail.com", "071 405 187", "Lucas García", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "569.445.507", 2, "A", null, null },
                    { 15, null, new DateTime(2022, 12, 17, 9, 36, 48, 913, DateTimeKind.Local).AddTicks(8417), "Ignacio81@nearbpo.com", "269 125 241", "Ignacio Zamora", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "552426948", 2, "A", null, null },
                    { 16, null, new DateTime(2022, 12, 17, 9, 36, 48, 913, DateTimeKind.Local).AddTicks(9932), "Roberto4@nearbpo.com", "054 363 320", "Roberto Quintero de la cruz", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "580 150 431", 2, "A", null, null },
                    { 17, null, new DateTime(2022, 12, 17, 9, 36, 48, 914, DateTimeKind.Local).AddTicks(1451), "Berta_Brito@gmail.com", "947 206 975", "Berta Brito", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5034-602-495", 2, "A", null, null },
                    { 18, null, new DateTime(2022, 12, 17, 9, 36, 48, 914, DateTimeKind.Local).AddTicks(3003), "Elizabeth9@hotmail.com", "680 985 975", "Elizabeth Sanabria", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5815-123-675", 2, "A", null, null },
                    { 19, null, new DateTime(2022, 12, 17, 9, 36, 48, 914, DateTimeKind.Local).AddTicks(4478), "Jennifer91@nearbpo.com", "968 013 045", "Jennifer Alva", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "527.626.755", 2, "A", null, null },
                    { 20, null, new DateTime(2022, 12, 17, 9, 36, 48, 914, DateTimeKind.Local).AddTicks(5893), "Armando34@yahoo.com", "589 684 372", "Armando Gallardo", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "592031256", 2, "A", null, null },
                    { 21, null, new DateTime(2022, 12, 17, 9, 36, 48, 914, DateTimeKind.Local).AddTicks(7364), "Patricio.Villanueva@gmail.com", "299 269 506", "Patricio Villanueva", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "507082969", 2, "A", null, null },
                    { 22, null, new DateTime(2022, 12, 17, 9, 36, 48, 914, DateTimeKind.Local).AddTicks(8939), "Carlota_Padilla59@nearbpo.com", "010 659 142", "Carlota Padilla", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "586 144 786", 2, "A", null, null },
                    { 23, null, new DateTime(2022, 12, 17, 9, 36, 48, 915, DateTimeKind.Local).AddTicks(248), "Camila_Rico2@gmail.com", "552 424 228", "Camila Rico", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "584962953", 2, "A", null, null },
                    { 24, null, new DateTime(2022, 12, 17, 9, 36, 48, 915, DateTimeKind.Local).AddTicks(1623), "Manuel10@nearbpo.com", "501 228 746", "Manuel Hinojosa", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "550 637 592", 2, "A", null, null },
                    { 25, null, new DateTime(2022, 12, 17, 9, 36, 48, 915, DateTimeKind.Local).AddTicks(3155), "Soledad_Verdugo@hotmail.com", "907 497 119", "Soledad Verdugo", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "567.693.679", 2, "A", null, null },
                    { 26, null, new DateTime(2022, 12, 17, 9, 36, 48, 915, DateTimeKind.Local).AddTicks(4617), "Guillermina.Urbina77@nearbpo.com", "669 893 331", "Guillermina Urbina", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "531.494.203", 2, "A", null, null },
                    { 27, null, new DateTime(2022, 12, 17, 9, 36, 48, 915, DateTimeKind.Local).AddTicks(6083), "Ines.Kadarrodriguez@nearbpo.com", "693 300 246", "Inés Kadar rodriguez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5308-656-609", 2, "A", null, null },
                    { 28, null, new DateTime(2022, 12, 17, 9, 36, 48, 915, DateTimeKind.Local).AddTicks(7585), "Lorenzo35@nearbpo.com", "338 246 994", "Lorenzo Sauceda", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5176-255-996", 2, "A", null, null },
                    { 29, null, new DateTime(2022, 12, 17, 9, 36, 48, 915, DateTimeKind.Local).AddTicks(9072), "Cristian.Cantu36@gmail.com", "758 719 728", "Cristian Cantú", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "569 323 908", 2, "A", null, null },
                    { 30, null, new DateTime(2022, 12, 17, 9, 36, 48, 916, DateTimeKind.Local).AddTicks(610), "Hugo24@corpfolder.com", "525 039 970", "Hugo Orozco", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5908-473-471", 2, "A", null, null },
                    { 31, null, new DateTime(2022, 12, 17, 9, 36, 48, 916, DateTimeKind.Local).AddTicks(2045), "Jose.Ojeda27@nearbpo.com", "365 930 817", "José Ojeda", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "550 933 557", 2, "A", null, null },
                    { 32, null, new DateTime(2022, 12, 17, 9, 36, 48, 916, DateTimeKind.Local).AddTicks(3561), "Arturo_Nino@nearbpo.com", "018 080 564", "Arturo Niño", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5651-444-657", 2, "A", null, null },
                    { 33, null, new DateTime(2022, 12, 17, 9, 36, 48, 916, DateTimeKind.Local).AddTicks(5061), "JoseAntonio44@corpfolder.com", "073 302 754", "José Antonio Espinosa", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "570783868", 2, "A", null, null },
                    { 34, null, new DateTime(2022, 12, 17, 9, 36, 48, 916, DateTimeKind.Local).AddTicks(7221), "Joaquin_Hinojosa@yahoo.com", "873 937 486", "Joaquín Hinojosa", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "510621873", 2, "A", null, null },
                    { 35, null, new DateTime(2022, 12, 17, 9, 36, 48, 916, DateTimeKind.Local).AddTicks(8823), "Adriana.Arenas61@corpfolder.com", "293 485 009", "Adriana Arenas", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5126-085-172", 2, "A", null, null },
                    { 36, null, new DateTime(2022, 12, 17, 9, 36, 48, 917, DateTimeKind.Local).AddTicks(305), "Daniel_Heredia28@hotmail.com", "538 705 898", "Daniel Heredia", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5813-422-709", 2, "A", null, null },
                    { 37, null, new DateTime(2022, 12, 17, 9, 36, 48, 917, DateTimeKind.Local).AddTicks(1801), "Marisol_Xana@nearbpo.com", "674 834 346", "Marisol Xana", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "553 535 186", 2, "A", null, null },
                    { 38, null, new DateTime(2022, 12, 17, 9, 36, 48, 917, DateTimeKind.Local).AddTicks(3300), "Mercedes7@corpfolder.com", "001 895 119", "Mercedes Grijalva", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "559.782.876", 2, "A", null, null },
                    { 39, null, new DateTime(2022, 12, 17, 9, 36, 48, 917, DateTimeKind.Local).AddTicks(4807), "Teresa_Dominguez@corpfolder.com", "540 447 448", "Teresa Domínguez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "522 473 618", 2, "A", null, null },
                    { 40, null, new DateTime(2022, 12, 17, 9, 36, 48, 917, DateTimeKind.Local).AddTicks(6273), "Eloisa.Karem94@corpfolder.com", "353 630 569", "Eloisa Karem", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "566591341", 2, "A", null, null },
                    { 41, null, new DateTime(2022, 12, 17, 9, 36, 48, 917, DateTimeKind.Local).AddTicks(7673), "Lola_Polanco75@yahoo.com", "805 284 411", "Lola Polanco", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "522.157.173", 2, "A", null, null },
                    { 42, null, new DateTime(2022, 12, 17, 9, 36, 48, 917, DateTimeKind.Local).AddTicks(9078), "Gilberto_Rincon@yahoo.com", "708 543 814", "Gilberto Rincón", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5561-128-461", 2, "A", null, null },
                    { 43, null, new DateTime(2022, 12, 17, 9, 36, 48, 918, DateTimeKind.Local).AddTicks(628), "Maricarmen.Roldan64@gmail.com", "651 133 381", "Maricarmen Roldán", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "553.831.802", 2, "A", null, null },
                    { 44, null, new DateTime(2022, 12, 17, 9, 36, 48, 918, DateTimeKind.Local).AddTicks(2023), "Mateo_Maya24@nearbpo.com", "621 133 180", "Mateo Maya", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "550.688.950", 2, "A", null, null },
                    { 45, null, new DateTime(2022, 12, 17, 9, 36, 48, 918, DateTimeKind.Local).AddTicks(3480), "Alexa39@nearbpo.com", "324 280 866", "Alexa Villareal", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "526.313.408", 2, "A", null, null },
                    { 46, null, new DateTime(2022, 12, 17, 9, 36, 48, 918, DateTimeKind.Local).AddTicks(4898), "Melany.Olivarez84@nearbpo.com", "975 919 911", "Melany Olivárez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5393-746-561", 2, "A", null, null },
                    { 47, null, new DateTime(2022, 12, 17, 9, 36, 48, 918, DateTimeKind.Local).AddTicks(6325), "Esmeralda13@corpfolder.com", "127 428 779", "Esmeralda Rincón", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "591 827 958", 2, "A", null, null },
                    { 48, null, new DateTime(2022, 12, 17, 9, 36, 48, 918, DateTimeKind.Local).AddTicks(7872), "German95@yahoo.com", "856 383 815", "Germán Jiménez", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "564 716 505", 2, "A", null, null },
                    { 49, null, new DateTime(2022, 12, 17, 9, 36, 48, 918, DateTimeKind.Local).AddTicks(9442), "Emmanuel.Ledesma37@gmail.com", "756 968 046", "Emmanuel Ledesma", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "528891399", 2, "A", null, null },
                    { 50, null, new DateTime(2022, 12, 17, 9, 36, 48, 919, DateTimeKind.Local).AddTicks(1045), "JuanPablo67@nearbpo.com", "507 080 646", "Juan Pablo Zaragoza", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "549262570", 2, "A", null, null },
                    { 51, null, new DateTime(2022, 12, 17, 9, 36, 48, 919, DateTimeKind.Local).AddTicks(2600), "Jesus.Delgado49@hotmail.com", "559 252 770", "Jesús Delgado", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "599753922", 2, "A", null, null },
                    { 52, null, new DateTime(2022, 12, 17, 9, 36, 48, 919, DateTimeKind.Local).AddTicks(4106), "Veronica28@hotmail.com", "378 558 019", "Verónica Bahena", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5319-106-070", 2, "A", null, null },
                    { 53, null, new DateTime(2022, 12, 17, 9, 36, 48, 919, DateTimeKind.Local).AddTicks(5586), "Juana.Garibay78@gmail.com", "641 605 894", "Juana Garibay", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "5658-793-975", 2, "A", null, null }
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
