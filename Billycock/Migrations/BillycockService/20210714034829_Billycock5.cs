using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations.BillycockService
{
    public partial class Billycock5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cuenta",
                table: "CUENTA",
                newName: "correo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "correo",
                table: "CUENTA",
                newName: "cuenta");
        }
    }
}
