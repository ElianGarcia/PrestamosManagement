using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamosManagement.Migrations
{
    public partial class First_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moras",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Cedula = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 40, nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PersonaID = table.Column<int>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 50, nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MorasDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoraID = table.Column<int>(nullable: false),
                    PrestamoID = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MorasDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MorasDetalle_Moras_MoraID",
                        column: x => x.MoraID,
                        principalTable: "Moras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "PersonaID", "Balance", "Cedula", "Direccion", "FechaDeNacimiento", "Nombres", "Telefono" },
                values: new object[] { 1, 345.34m, "05600345926", "Calle Roberto Acevedo #34", new DateTime(2020, 6, 19, 8, 35, 3, 253, DateTimeKind.Local).AddTicks(7591), "Juan Alberto", "8292655182" });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "ID", "Balance", "Concepto", "Fecha", "Monto", "PersonaID" },
                values: new object[] { 1, 345.34m, "Terrenos", new DateTime(2020, 6, 19, 8, 35, 3, 247, DateTimeKind.Local).AddTicks(3311), 345.34m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MorasDetalle_MoraID",
                table: "MorasDetalle",
                column: "MoraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MorasDetalle");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Moras");
        }
    }
}
