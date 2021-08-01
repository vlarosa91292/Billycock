using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations
{
    public partial class CambiosdellavesenPCUPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIOPLATAFORMACUENTA",
                table: "USUARIOPLATAFORMACUENTA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PLATAFORMACUENTA",
                table: "PLATAFORMACUENTA");

            migrationBuilder.AddColumn<string>(
                name: "idUsuarioPlataformaCuenta",
                table: "USUARIOPLATAFORMACUENTA",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "idPlataformaCuenta",
                table: "PLATAFORMACUENTA",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIOPLATAFORMACUENTA",
                table: "USUARIOPLATAFORMACUENTA",
                column: "idUsuarioPlataformaCuenta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PLATAFORMACUENTA",
                table: "PLATAFORMACUENTA",
                column: "idPlataformaCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPLATAFORMACUENTA_idUsuario",
                table: "USUARIOPLATAFORMACUENTA",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PLATAFORMACUENTA_idCuenta",
                table: "PLATAFORMACUENTA",
                column: "idCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIOPLATAFORMACUENTA",
                table: "USUARIOPLATAFORMACUENTA");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOPLATAFORMACUENTA_idUsuario",
                table: "USUARIOPLATAFORMACUENTA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PLATAFORMACUENTA",
                table: "PLATAFORMACUENTA");

            migrationBuilder.DropIndex(
                name: "IX_PLATAFORMACUENTA_idCuenta",
                table: "PLATAFORMACUENTA");

            migrationBuilder.DropColumn(
                name: "idUsuarioPlataformaCuenta",
                table: "USUARIOPLATAFORMACUENTA");

            migrationBuilder.DropColumn(
                name: "idPlataformaCuenta",
                table: "PLATAFORMACUENTA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIOPLATAFORMACUENTA",
                table: "USUARIOPLATAFORMACUENTA",
                columns: new[] { "idUsuario", "idPlataforma", "idCuenta" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PLATAFORMACUENTA",
                table: "PLATAFORMACUENTA",
                columns: new[] { "idCuenta", "idPlataforma" });
        }
    }
}
