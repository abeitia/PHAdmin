using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
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
                    { 1, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9252), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9276), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9277), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9278), 2, "A", "A", null, null },
                    { 5, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9280), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9281), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9282), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9285), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9289), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9290), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9292), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9293), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 12, 5, 20, 57, 26, 625, DateTimeKind.Local).AddTicks(9294), 3, "E", "A", null, null }
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
                    { 1, null, new DateTime(2022, 12, 5, 20, 57, 26, 628, DateTimeKind.Local).AddTicks(9079), "Brayan_Nanez@gmail.com", "283 028 108", "Brayan Ñañez", "1234", "584841386", 2, "A", null, null },
                    { 2, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(469), "Maximiliano.Colon44@nearbpo.com", "733 331 748", "Maximiliano Colón", "1234", "530 157 857", 2, "A", null, null },
                    { 3, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(1370), "Homero.Romo@yahoo.com", "015 950 256", "Homero Romo", "1234", "554689291", 2, "A", null, null },
                    { 4, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(2259), "Emmanuel.Gonzalez51@gmail.com", "583 532 759", "Emmanuel González", "1234", "594 343 844", 2, "A", null, null },
                    { 5, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(3279), "Rosalia84@gmail.com", "226 537 942", "Rosalia Madrigal", "1234", "500.048.658", 2, "A", null, null },
                    { 6, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(4159), "Marisol.Yebra@yahoo.com", "730 550 639", "Marisol Yebra", "1234", "5908-714-003", 2, "A", null, null },
                    { 7, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(4955), "Alexander_Nazario@nearbpo.com", "027 675 669", "Alexander Nazario", "1234", "514.505.007", 2, "A", null, null },
                    { 8, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(5797), "Enrique_Contreras@hotmail.com", "410 132 278", "Enrique Contreras", "1234", "599.910.399", 2, "A", null, null },
                    { 9, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(6570), "Cecilia55@nearbpo.com", "928 362 300", "Cecilia Villa", "1234", "579364550", 2, "A", null, null },
                    { 10, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(7321), "Joaquin.Vargas@corpfolder.com", "211 561 071", "Joaquín Vargas", "1234", "599440197", 2, "A", null, null },
                    { 11, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(8299), "Maximiliano_Montemayor34@gmail.com", "703 549 477", "Maximiliano Montemayor", "1234", "572.652.006", 2, "A", null, null },
                    { 12, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(9163), "AnaVictoria.Kardachesoto18@corpfolder.com", "996 616 892", "Ana Victoria Kardache soto", "1234", "5550-741-473", 2, "A", null, null },
                    { 13, null, new DateTime(2022, 12, 5, 20, 57, 26, 629, DateTimeKind.Local).AddTicks(9943), "Gonzalo26@nearbpo.com", "965 101 587", "Gonzalo Quevedo", "1234", "556 529 773", 2, "A", null, null },
                    { 14, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(720), "Uriel_Quinones@gmail.com", "345 099 857", "Uriel Quiñones", "1234", "513 302 073", 2, "A", null, null },
                    { 15, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(1525), "Timoteo_Gaitan33@hotmail.com", "830 367 041", "Timoteo Gaitán", "1234", "536.146.009", 2, "A", null, null },
                    { 16, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(2288), "Hugo.Gil@hotmail.com", "765 996 566", "Hugo Gil", "1234", "580 890 390", 2, "A", null, null },
                    { 17, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(3153), "Timoteo.Lopez@hotmail.com", "975 595 059", "Timoteo López", "1234", "5160-513-640", 2, "A", null, null },
                    { 18, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(3998), "Miguel_Quevedo65@gmail.com", "558 098 240", "Miguel Quevedo", "1234", "577 750 964", 2, "A", null, null },
                    { 19, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(4736), "Marcela71@yahoo.com", "560 083 636", "Marcela Franco", "1234", "551 666 915", 2, "A", null, null },
                    { 20, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(5494), "Adela_Portillo@corpfolder.com", "095 208 757", "Adela Portillo", "1234", "568654343", 2, "A", null, null },
                    { 21, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(6227), "Marilu10@hotmail.com", "246 013 726", "Marilu Arteaga", "1234", "573179688", 2, "A", null, null },
                    { 22, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(6986), "Horacio6@nearbpo.com", "419 486 501", "Horacio Saldaña", "1234", "520122963", 2, "A", null, null },
                    { 23, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(7705), "Lourdes35@gmail.com", "735 557 217", "Lourdes Limón", "1234", "5707-727-371", 2, "A", null, null },
                    { 24, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(8477), "Valentina_Estrada@corpfolder.com", "708 632 237", "Valentina Estrada", "1234", "5946-576-688", 2, "A", null, null },
                    { 25, null, new DateTime(2022, 12, 5, 20, 57, 26, 630, DateTimeKind.Local).AddTicks(9311), "Gilberto.Abreu@gmail.com", "835 722 927", "Gilberto Abreu", "1234", "5039-268-670", 2, "A", null, null },
                    { 26, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(104), "MariaElena_Pagan78@hotmail.com", "920 130 705", "María Elena Pagan", "1234", "521.638.529", 2, "A", null, null },
                    { 27, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(945), "Emmanuel.Urena@gmail.com", "023 320 104", "Emmanuel Ureña", "1234", "5069-404-288", 2, "A", null, null },
                    { 28, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(1706), "Rosalia32@corpfolder.com", "688 711 506", "Rosalia Leal", "1234", "584.237.147", 2, "A", null, null },
                    { 29, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(2447), "Conchita_Cintron6@gmail.com", "956 961 486", "Conchita Cintrón", "1234", "590 193 444", 2, "A", null, null },
                    { 30, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(3285), "Miranda_Miramontes@yahoo.com", "782 480 792", "Miranda Miramontes", "1234", "5150-266-494", 2, "A", null, null },
                    { 31, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(4039), "Juana64@yahoo.com", "884 346 925", "Juana Trejo", "1234", "591701764", 2, "A", null, null },
                    { 32, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(4865), "Marcela.Mascarenas@yahoo.com", "036 962 512", "Marcela Mascareñas", "1234", "527 832 934", 2, "A", null, null },
                    { 33, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(5644), "Lola34@corpfolder.com", "754 195 378", "Lola Montoya", "1234", "529515712", 2, "A", null, null },
                    { 34, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(6457), "Cecilia_Quinta29@gmail.com", "123 182 370", "Cecilia Quinta", "1234", "5971-907-874", 2, "A", null, null },
                    { 35, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(7366), "Carlos23@yahoo.com", "639 082 882", "Carlos Jimínez", "1234", "508829572", 2, "A", null, null },
                    { 36, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(8184), "Regina.Guajardo@yahoo.com", "345 393 540", "Regina Guajardo", "1234", "511995009", 2, "A", null, null },
                    { 37, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(8972), "Florencia29@nearbpo.com", "694 759 291", "Florencia Madrigal", "1234", "570.726.260", 2, "A", null, null },
                    { 38, null, new DateTime(2022, 12, 5, 20, 57, 26, 631, DateTimeKind.Local).AddTicks(9741), "Monica.Zamarreno@hotmail.com", "905 019 105", "Mónica Zamarreno", "1234", "536579450", 2, "A", null, null },
                    { 39, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(576), "Carolina_Cardona80@yahoo.com", "672 117 371", "Carolina Cardona", "1234", "5647-227-623", 2, "A", null, null },
                    { 40, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(1341), "Miguel61@nearbpo.com", "292 287 034", "Miguel Ceballos", "1234", "517 812 188", 2, "A", null, null },
                    { 41, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(2093), "JuanPablo.Arroyo@hotmail.com", "291 454 106", "Juan Pablo Arroyo", "1234", "5576-458-733", 2, "A", null, null },
                    { 42, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(2871), "Alejandra_Correa@hotmail.com", "452 113 871", "Alejandra Correa", "1234", "5919-831-711", 2, "A", null, null },
                    { 43, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(3599), "Eloisa_Botello32@nearbpo.com", "291 979 987", "Eloisa Botello", "1234", "514236652", 2, "A", null, null },
                    { 44, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(4498), "Ximena_Barrera@yahoo.com", "769 939 018", "Ximena Barrera", "1234", "527.547.626", 2, "A", null, null },
                    { 45, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(5309), "Hugo.Farias@hotmail.com", "367 819 174", "Hugo Farías", "1234", "5954-556-807", 2, "A", null, null },
                    { 46, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(6125), "Valeria_Valdez@gmail.com", "801 835 182", "Valeria Valdez", "1234", "5050-035-626", 2, "A", null, null },
                    { 47, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(6867), "Julieta23@hotmail.com", "299 455 618", "Julieta Rolón", "1234", "512383960", 2, "A", null, null },
                    { 48, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(7656), "FranciscoJavier_Arriaga@gmail.com", "063 575 328", "Francisco Javier Arriaga", "1234", "552342069", 2, "A", null, null },
                    { 49, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(8571), "Carmen.Vasquez80@corpfolder.com", "071 055 222", "Carmen Vásquez", "1234", "509 880 223", 2, "A", null, null },
                    { 50, null, new DateTime(2022, 12, 5, 20, 57, 26, 632, DateTimeKind.Local).AddTicks(9870), "Nicole.Valentin24@corpfolder.com", "522 490 655", "Nicole Valentín", "1234", "567.364.522", 2, "A", null, null },
                    { 51, null, new DateTime(2022, 12, 5, 20, 57, 26, 633, DateTimeKind.Local).AddTicks(1648), "Silvia.Benitez93@nearbpo.com", "817 942 022", "Silvia Benítez", "1234", "546.854.471", 2, "A", null, null },
                    { 52, null, new DateTime(2022, 12, 5, 20, 57, 26, 633, DateTimeKind.Local).AddTicks(2852), "Emilio_Cordova@corpfolder.com", "378 193 312", "Emilio Córdova", "1234", "561 509 368", 2, "A", null, null },
                    { 53, null, new DateTime(2022, 12, 5, 20, 57, 26, 633, DateTimeKind.Local).AddTicks(3819), "Benito.Marquez27@gmail.com", "681 605 853", "Benito Márquez", "1234", "537448478", 2, "A", null, null }
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
