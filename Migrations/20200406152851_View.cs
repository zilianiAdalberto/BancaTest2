using Microsoft.EntityFrameworkCore.Migrations;
//creato migrazione customizzata con vista che ci serve
namespace BancaTest2.Migrations
{
    public partial class View : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE VIEW MovimentiUtente
AS
SELECT CLienteId, MovimentoData, Cifra from MovimentiDare
UNION ALL
SELECT CLienteId, MovimentoData, Cifra from MovimentiAvere
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW MovimentiUtente");
        }
    }
}
