using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUENTA",
                columns: table => new
                {
                    idCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diminutivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    netflix = table.Column<int>(type: "int", nullable: false),
                    amazon = table.Column<int>(type: "int", nullable: false),
                    disney = table.Column<int>(type: "int", nullable: false),
                    hbo = table.Column<int>(type: "int", nullable: false),
                    youtube = table.Column<int>(type: "int", nullable: false),
                    spotify = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idEstado = table.Column<int>(type: "int", nullable: true)
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
                name: "HISTORY",
                columns: table => new
                {
                    idHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORY", x => x.idHistory);
                });

            migrationBuilder.CreateTable(
                name: "PLATAFORMA",
                columns: table => new
                {
                    idPlataforma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idEstado = table.Column<int>(type: "int", nullable: true),
                    numeroMaximoUsuarios = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false)
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
                    pago = table.Column<int>(type: "int", nullable: true)
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
                    CuentaidCuenta = table.Column<int>(type: "int", nullable: true),
                    PlataformaidPlataforma = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLATAFORMACUENTA", x => new { x.idCuenta, x.idPlataforma });
                    table.ForeignKey(
                        name: "FK_PLATAFORMACUENTA_CUENTA_idCuenta",
                        column: x => x.CuentaidCuenta,
                        principalTable: "CUENTA",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PLATAFORMACUENTA_PLATAFORMA_idPlataforma",
                        column: x => x.PlataformaidPlataforma,
                        principalTable: "PLATAFORMA",
                        principalColumn: "idPlataforma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOPLATAFORMA",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idPlataforma = table.Column<int>(type: "int", nullable: false),
                    idCuenta = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    CuentaidCuenta = table.Column<int>(type: "int", nullable: true),
                    PlataformaidPlataforma = table.Column<int>(type: "int", nullable: true),
                    UsuarioidUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOPLATAFORMA", x => new { x.idUsuario, x.idPlataforma, x.idCuenta });
                    table.ForeignKey(
                        name: "FK_USUARIOPLATAFORMA_CUENTA_idCuenta",
                        column: x => x.CuentaidCuenta,
                        principalTable: "CUENTA",
                        principalColumn: "idCuenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIOPLATAFORMA_PLATAFORMA_idPlataforma",
                        column: x => x.PlataformaidPlataforma,
                        principalTable: "PLATAFORMA",
                        principalColumn: "idPlataforma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIOPLATAFORMA_USUARIO_idUsuario",
                        column: x => x.UsuarioidUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLATAFORMACUENTA_idCuenta",
                table: "PLATAFORMACUENTA",
                column: "CuentaidCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_PLATAFORMACUENTA_idPlataforma",
                table: "PLATAFORMACUENTA",
                column: "PlataformaidPlataforma");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPLATAFORMA_idCuenta",
                table: "USUARIOPLATAFORMA",
                column: "CuentaidCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPLATAFORMA_idPlataforma",
                table: "USUARIOPLATAFORMA",
                column: "PlataformaidPlataforma");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPLATAFORMA_idUsuario",
                table: "USUARIOPLATAFORMA",
                column: "UsuarioidUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESTADO");

            migrationBuilder.DropTable(
                name: "HISTORY");

            migrationBuilder.DropTable(
                name: "PLATAFORMACUENTA");

            migrationBuilder.DropTable(
                name: "USUARIOPLATAFORMA");

            migrationBuilder.DropTable(
                name: "CUENTA");

            migrationBuilder.DropTable(
                name: "PLATAFORMA");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
