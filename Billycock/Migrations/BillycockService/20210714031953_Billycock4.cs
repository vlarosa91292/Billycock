using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations.BillycockService
{
    public partial class Billycock4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuario",
                table: "PLATAFORMACUENTA");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "CUENTA",
                newName: "cuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cuenta",
                table: "CUENTA",
                newName: "nombre");

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "PLATAFORMACUENTA",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
