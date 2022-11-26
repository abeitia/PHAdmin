using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHAdmin.API.Migrations
{
    /// <inheritdoc />
    public partial class New7 : Migration
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
                    { 1, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9596), 1, "A", "A", null, null },
                    { 2, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9620), 1, "B", "A", null, null },
                    { 3, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9621), 1, "C", "A", null, null },
                    { 4, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9622), 2, "A", "A", null, null },
                    { 5, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9623), 2, "B", "A", null, null },
                    { 6, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9625), 2, "C", "A", null, null },
                    { 7, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9627), 2, "D", "A", null, null },
                    { 8, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9629), 2, "E", "A", null, null },
                    { 9, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9630), 3, "A", "A", null, null },
                    { 10, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9631), 3, "B", "A", null, null },
                    { 11, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9632), 3, "C", "A", null, null },
                    { 12, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9632), 3, "D", "A", null, null },
                    { 13, null, new DateTime(2022, 11, 23, 10, 30, 48, 675, DateTimeKind.Local).AddTicks(9634), 3, "E", "A", null, null }
                });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "ExpenseName" },
                values: new object[,]
                {
                    { 1, "Agua" },
                    { 2, "Luz" }
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
                    { 1, null, new DateTime(2022, 11, 23, 10, 30, 48, 679, DateTimeKind.Local).AddTicks(598), "Ernesto_Kortahernandez68@nearbpo.com", "950 010 611", "Ernesto Korta hernandez", "1234", "5475-290-045", 2, "A", null, null },
                    { 2, null, new DateTime(2022, 11, 23, 10, 30, 48, 679, DateTimeKind.Local).AddTicks(1722), "Clara19@hotmail.com", "277 297 610", "Clara Rico", "1234", "5212-875-635", 2, "A", null, null },
                    { 3, null, new DateTime(2022, 11, 23, 10, 30, 48, 679, DateTimeKind.Local).AddTicks(3284), "Rodrigo.Armenta@gmail.com", "220 603 799", "Rodrigo Armenta", "1234", "561 419 266", 2, "A", null, null },
                    { 4, null, new DateTime(2022, 11, 23, 10, 30, 48, 679, DateTimeKind.Local).AddTicks(4502), "Xochitl_Barragan29@nearbpo.com", "310 436 829", "Xochitl Barragán", "1234", "5743-690-681", 2, "A", null, null },
                    { 5, null, new DateTime(2022, 11, 23, 10, 30, 48, 679, DateTimeKind.Local).AddTicks(7542), "JoseMiguel_Galvan56@hotmail.com", "759 763 154", "José Miguel Galván", "1234", "558674507", 2, "A", null, null },
                    { 6, null, new DateTime(2022, 11, 23, 10, 30, 48, 679, DateTimeKind.Local).AddTicks(9780), "JoseAntonio28@gmail.com", "197 452 543", "José Antonio Huerta", "1234", "569 578 628", 2, "A", null, null },
                    { 7, null, new DateTime(2022, 11, 23, 10, 30, 48, 680, DateTimeKind.Local).AddTicks(1586), "Micaela.Galvan@gmail.com", "611 919 481", "Micaela Galván", "1234", "574597869", 2, "A", null, null },
                    { 8, null, new DateTime(2022, 11, 23, 10, 30, 48, 680, DateTimeKind.Local).AddTicks(3340), "JoseMiguel_Trujillo@hotmail.com", "403 764 178", "José Miguel Trujillo", "1234", "515 157 581", 2, "A", null, null },
                    { 9, null, new DateTime(2022, 11, 23, 10, 30, 48, 680, DateTimeKind.Local).AddTicks(5325), "Elsa_Zambrano@gmail.com", "157 373 283", "Elsa Zambrano", "1234", "530.275.100", 2, "A", null, null },
                    { 10, null, new DateTime(2022, 11, 23, 10, 30, 48, 680, DateTimeKind.Local).AddTicks(7360), "Valeria.Paredes56@nearbpo.com", "499 142 867", "Valeria Paredes", "1234", "521434082", 2, "A", null, null },
                    { 11, null, new DateTime(2022, 11, 23, 10, 30, 48, 680, DateTimeKind.Local).AddTicks(9287), "Irene15@hotmail.com", "790 779 813", "Irene Gallegos", "1234", "5404-011-006", 2, "A", null, null },
                    { 12, null, new DateTime(2022, 11, 23, 10, 30, 48, 681, DateTimeKind.Local).AddTicks(429), "Andres_Razo@gmail.com", "106 886 617", "Andrés Razo", "1234", "529.179.377", 2, "A", null, null },
                    { 13, null, new DateTime(2022, 11, 23, 10, 30, 48, 681, DateTimeKind.Local).AddTicks(1596), "Elizabeth.Salas40@yahoo.com", "007 136 997", "Elizabeth Salas", "1234", "537 929 545", 2, "A", null, null },
                    { 14, null, new DateTime(2022, 11, 23, 10, 30, 48, 681, DateTimeKind.Local).AddTicks(3645), "AlondraRomina20@gmail.com", "296 923 808", "Alondra Romina Calvillo", "1234", "5670-936-558", 2, "A", null, null },
                    { 15, null, new DateTime(2022, 11, 23, 10, 30, 48, 681, DateTimeKind.Local).AddTicks(5215), "MariaGuadalupe83@corpfolder.com", "311 522 981", "María Guadalupe Calvillo", "1234", "515 557 394", 2, "A", null, null },
                    { 16, null, new DateTime(2022, 11, 23, 10, 30, 48, 681, DateTimeKind.Local).AddTicks(7071), "Martin57@gmail.com", "271 305 658", "Martín Carbajal", "1234", "5345-422-103", 2, "A", null, null },
                    { 17, null, new DateTime(2022, 11, 23, 10, 30, 48, 681, DateTimeKind.Local).AddTicks(8348), "Agustin_Pineda@gmail.com", "635 803 257", "Agustín Pineda", "1234", "5593-120-904", 2, "A", null, null },
                    { 18, null, new DateTime(2022, 11, 23, 10, 30, 48, 681, DateTimeKind.Local).AddTicks(9907), "JoseMaria.Zamarripa@gmail.com", "394 644 769", "José María Zamarripa", "1234", "5957-915-668", 2, "A", null, null },
                    { 19, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(714), "JuanManuel_Kyra@gmail.com", "846 556 330", "Juan Manuel Kyra", "1234", "5119-003-019", 2, "A", null, null },
                    { 20, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(1411), "Jeronimo68@gmail.com", "399 463 496", "Jerónimo Aguayo", "1234", "533 533 172", 2, "A", null, null },
                    { 21, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(2086), "Cristobal6@corpfolder.com", "563 693 076", "Cristobal Gonzales", "1234", "551 807 570", 2, "A", null, null },
                    { 22, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(2848), "Paulina.Ocampo@hotmail.com", "706 936 853", "Paulina Ocampo", "1234", "5412-813-216", 2, "A", null, null },
                    { 23, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(3572), "Andres.Arenas@yahoo.com", "316 922 574", "Andrés Arenas", "1234", "525 190 083", 2, "A", null, null },
                    { 24, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(4317), "Carmen48@nearbpo.com", "885 494 955", "Carmen Collado", "1234", "5504-462-799", 2, "A", null, null },
                    { 25, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(5100), "Eloisa64@gmail.com", "043 897 743", "Eloisa Karen", "1234", "5288-441-824", 2, "A", null, null },
                    { 26, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(5695), "Luis_Tapia@corpfolder.com", "478 737 117", "Luis Tapia", "1234", "545 669 344", 2, "A", null, null },
                    { 27, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(6301), "Maria.Tejeda64@hotmail.com", "690 060 819", "María Tejeda", "1234", "562.342.082", 2, "A", null, null },
                    { 28, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(6887), "Enrique_Nava@yahoo.com", "269 037 750", "Enrique Nava", "1234", "5416-287-909", 2, "A", null, null },
                    { 29, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(7583), "JuanCarlos_Sanchez70@gmail.com", "168 971 489", "Juan Carlos Sánchez", "1234", "575.556.685", 2, "A", null, null },
                    { 30, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(8244), "Marcela_Anaya41@gmail.com", "793 879 396", "Marcela Anaya", "1234", "558193948", 2, "A", null, null },
                    { 31, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(8935), "JoseLuis23@yahoo.com", "297 981 094", "José Luis Mateo", "1234", "5307-969-375", 2, "A", null, null },
                    { 32, null, new DateTime(2022, 11, 23, 10, 30, 48, 682, DateTimeKind.Local).AddTicks(9559), "Manuel82@gmail.com", "595 615 410", "Manuel Medina", "1234", "5900-840-814", 2, "A", null, null },
                    { 33, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(174), "AnaVictoria_Valenzuela@gmail.com", "910 049 493", "Ana Victoria Valenzuela", "1234", "5685-301-026", 2, "A", null, null },
                    { 34, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(855), "Gonzalo23@gmail.com", "713 033 421", "Gonzalo Kardache soto", "1234", "5341-605-345", 2, "A", null, null },
                    { 35, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(1535), "MariaGuadalupe85@corpfolder.com", "485 756 696", "María Guadalupe Roldán", "1234", "566444143", 2, "A", null, null },
                    { 36, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(2167), "Teresa_Candelaria@gmail.com", "979 387 362", "Teresa Candelaria", "1234", "588049213", 2, "A", null, null },
                    { 37, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(2850), "David.Alarcon84@hotmail.com", "647 875 194", "David Alarcón", "1234", "574.165.963", 2, "A", null, null },
                    { 38, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(3502), "Lucas_Olivo@yahoo.com", "548 048 784", "Lucas Olivo", "1234", "5360-157-742", 2, "A", null, null },
                    { 39, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(4111), "Emmanuel_Ortega@corpfolder.com", "031 876 188", "Emmanuel Ortega", "1234", "541.003.102", 2, "A", null, null },
                    { 40, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(4758), "Isaac86@nearbpo.com", "744 626 938", "Isaac Saldivar", "1234", "556 677 247", 2, "A", null, null },
                    { 41, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(5455), "Emilio.Trujillo71@yahoo.com", "562 102 350", "Emilio Trujillo", "1234", "552.767.965", 2, "A", null, null },
                    { 42, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(6137), "RosaMaria_Varela@yahoo.com", "590 206 611", "Rosa María Varela", "1234", "511733058", 2, "A", null, null },
                    { 43, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(6770), "Raul64@gmail.com", "378 672 778", "Raúl Delatorre", "1234", "5445-932-089", 2, "A", null, null },
                    { 44, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(7531), "Daniela.Nino@hotmail.com", "016 559 205", "Daniela Niño", "1234", "5072-233-485", 2, "A", null, null },
                    { 45, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(8385), "Alan.Campos@corpfolder.com", "503 732 745", "Alan Campos", "1234", "533466826", 2, "A", null, null },
                    { 46, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(9158), "Lorena_Canales@hotmail.com", "986 437 127", "Lorena Canales", "1234", "568.968.883", 2, "A", null, null },
                    { 47, null, new DateTime(2022, 11, 23, 10, 30, 48, 683, DateTimeKind.Local).AddTicks(9933), "Alexa.Casanova16@corpfolder.com", "143 542 470", "Alexa Casanova", "1234", "501 105 902", 2, "A", null, null },
                    { 48, null, new DateTime(2022, 11, 23, 10, 30, 48, 684, DateTimeKind.Local).AddTicks(696), "Sancho.Laboy@gmail.com", "569 687 015", "Sancho Laboy", "1234", "503 340 865", 2, "A", null, null },
                    { 49, null, new DateTime(2022, 11, 23, 10, 30, 48, 684, DateTimeKind.Local).AddTicks(1354), "Claudio57@gmail.com", "407 191 642", "Claudio Agosto", "1234", "574 973 495", 2, "A", null, null },
                    { 50, null, new DateTime(2022, 11, 23, 10, 30, 48, 684, DateTimeKind.Local).AddTicks(2073), "Marisol_Quezada@hotmail.com", "128 463 155", "Marisol Quezada", "1234", "594375166", 2, "A", null, null },
                    { 51, null, new DateTime(2022, 11, 23, 10, 30, 48, 684, DateTimeKind.Local).AddTicks(2826), "Araceli.Mercado45@nearbpo.com", "232 633 164", "Araceli Mercado", "1234", "549 778 690", 2, "A", null, null },
                    { 52, null, new DateTime(2022, 11, 23, 10, 30, 48, 684, DateTimeKind.Local).AddTicks(3545), "Emilia.Armijo@hotmail.com", "102 754 959", "Emilia Armijo", "1234", "528 645 193", 2, "A", null, null },
                    { 53, null, new DateTime(2022, 11, 23, 10, 30, 48, 684, DateTimeKind.Local).AddTicks(4235), "Olivia_Loera@hotmail.com", "600 301 717", "Olivia Loera", "1234", "5232-430-218", 2, "A", null, null }
                });

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
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
