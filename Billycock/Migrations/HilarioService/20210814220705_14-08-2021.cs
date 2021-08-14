using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations.HilarioService
{
    public partial class _14082021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "HISTORIA",
                columns: table => new
                {
                    idHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    integracion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORIA", x => x.idHistory);
                });

            migrationBuilder.CreateTable(
                name: "LINEA",
                columns: table => new
                {
                    idLinea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LINEA", x => x.idLinea);
                });

            migrationBuilder.CreateTable(
                name: "PROVEEDOR",
                columns: table => new
                {
                    idProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR", x => x.idProveedor);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoBarra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idlinea = table.Column<int>(type: "int", nullable: false),
                    idProveedor = table.Column<int>(type: "int", nullable: false),
                    fechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    loteCaja = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<double>(type: "float", nullable: false),
                    LineaidLinea = table.Column<int>(type: "int", nullable: true),
                    ProveedoridProveedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_LINEA_LineaidLinea",
                        column: x => x.LineaidLinea,
                        principalTable: "LINEA",
                        principalColumn: "idLinea",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_PROVEEDOR_ProveedoridProveedor",
                        column: x => x.ProveedoridProveedor,
                        principalTable: "PROVEEDOR",
                        principalColumn: "idProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OFERTA",
                columns: table => new
                {
                    idOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoBarra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precioOferta = table.Column<double>(type: "float", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: false),
                    ProductoidProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFERTA", x => x.idOferta);
                    table.ForeignKey(
                        name: "FK_OFERTA_PRODUCTO_ProductoidProducto",
                        column: x => x.ProductoidProducto,
                        principalTable: "PRODUCTO",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OFERTA_ProductoidProducto",
                table: "OFERTA",
                column: "ProductoidProducto");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTO_LineaidLinea",
                table: "PRODUCTO",
                column: "LineaidLinea");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTO_ProveedoridProveedor",
                table: "PRODUCTO",
                column: "ProveedoridProveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESTADO");

            migrationBuilder.DropTable(
                name: "HISTORIA");

            migrationBuilder.DropTable(
                name: "OFERTA");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "LINEA");

            migrationBuilder.DropTable(
                name: "PROVEEDOR");
        }
    }
}
