using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaTest2.Migrations
{
    public partial class MigrVista6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentiUtente",
                columns: table => new
                {
                    MovimentoUtenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    MovimentoData = table.Column<DateTime>(nullable: false),
                    Cifra = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentiUtente", x => x.MovimentoUtenteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentiUtente");
        }
    }
}
