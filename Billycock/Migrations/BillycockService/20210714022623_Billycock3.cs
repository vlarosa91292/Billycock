using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations.BillycockService
{
    public partial class Billycock3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "CUENTA");

            migrationBuilder.DropColumn(
                name: "password",
                table: "CUENTA");

            migrationBuilder.AddColumn<string>(
                name: "clave",
                table: "PLATAFORMACUENTA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "PLATAFORMACUENTA",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clave",
                table: "PLATAFORMACUENTA");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "PLATAFORMACUENTA");

            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "CUENTA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "CUENTA",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
