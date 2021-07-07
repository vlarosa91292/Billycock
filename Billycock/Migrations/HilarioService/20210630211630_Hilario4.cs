using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations
{
    public partial class Hilario4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoidProducto",
                table: "OFERTA",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OFERTA_ProductoidProducto",
                table: "OFERTA",
                column: "ProductoidProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_OFERTA_PRODUCTO_ProductoidProducto",
                table: "OFERTA",
                column: "ProductoidProducto",
                principalTable: "PRODUCTO",
                principalColumn: "idProducto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OFERTA_PRODUCTO_ProductoidProducto",
                table: "OFERTA");

            migrationBuilder.DropIndex(
                name: "IX_OFERTA_ProductoidProducto",
                table: "OFERTA");

            migrationBuilder.DropColumn(
                name: "ProductoidProducto",
                table: "OFERTA");
        }
    }
}
