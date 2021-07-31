using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations
{
    public partial class XD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUENTA",
                columns: table => new
                {
                    idCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diminutivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUENTA", x => x.idCuenta);
                });

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
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    integracion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORIA", x => x.idHistory);
                });

            migrationBuilder.CreateTable(
                name: "PLATAFORMA",
                columns: table => new
                {
                    idPlataforma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroMaximoUsuarios = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLATAFORMA", x => x.idPlataforma);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    idEstado = table.Column<int>(type: "int", nullable: true),
                    facturacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pago = table.Column<int>(type: "int", nullable: true),
                    pin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "PLATAFORMACUENTA",
                columns: table => new
                {
                    idPlataforma = table.Column<int>(type: "int", nullable: false),
                    idCuenta = table.Column<int>(type: "int", nullable: false),
                    usuariosdisponibles = table.Column<int>(type: "int", nullable: true),
                    fechaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLATAFORMACUENTA", x => new { x.idCuenta, x.idPlataforma });
                    table.ForeignKey(
                        name: "FK_PLATAFORMACUENTA_CUENTA_idCuenta",
                        column: x => x.idCuenta,
                        principalTable: "CUENTA",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLATAFORMACUENTA_PLATAFORMA_idPlataforma",
                        column: x => x.idPlataforma,
                        principalTable: "PLATAFORMA",
                        principalColumn: "idPlataforma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOPLATAFORMACUENTA",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idPlataforma = table.Column<int>(type: "int", nullable: false),
                    idCuenta = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOPLATAFORMACUENTA", x => new { x.idUsuario, x.idPlataforma, x.idCuenta });
                    table.ForeignKey(
                        name: "FK_USUARIOPLATAFORMACUENTA_CUENTA_idCuenta",
                        column: x => x.idCuenta,
                        principalTable: "CUENTA",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOPLATAFORMACUENTA_PLATAFORMA_idPlataforma",
                        column: x => x.idPlataforma,
                        principalTable: "PLATAFORMA",
                        principalColumn: "idPlataforma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOPLATAFORMACUENTA_USUARIO_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLATAFORMACUENTA_idPlataforma",
                table: "PLATAFORMACUENTA",
                column: "idPlataforma");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPLATAFORMACUENTA_idCuenta",
                table: "USUARIOPLATAFORMACUENTA",
                column: "idCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPLATAFORMACUENTA_idPlataforma",
                table: "USUARIOPLATAFORMACUENTA",
                column: "idPlataforma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESTADO");

            migrationBuilder.DropTable(
                name: "HISTORIA");

            migrationBuilder.DropTable(
                name: "PLATAFORMACUENTA");

            migrationBuilder.DropTable(
                name: "USUARIOPLATAFORMACUENTA");

            migrationBuilder.DropTable(
                name: "CUENTA");

            migrationBuilder.DropTable(
                name: "PLATAFORMA");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
