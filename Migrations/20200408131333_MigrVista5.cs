using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaTest2.Migrations
{
    public partial class MigrVista5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentiUtente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentiUtente",
                columns: table => new
                {
                    MovimentoUtenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cifra = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    MovimentoData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentiUtente", x => x.MovimentoUtenteId);
                });
        }
    }
}
