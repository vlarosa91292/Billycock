using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations
{
    public partial class CambiodefechaDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fechaInscripcion",
                table: "USUARIO",
                type: "varchar(50)",
                nullable: true,
                defaultValueSql: "CAST(CAST(GETUTCDATE() AS DATETIMEOFFSET) AT TIME ZONE 'CENTRAL STANDARD TIME (MEXICO)' AS DATETIME)",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fechaInscripcion",
                table: "USUARIO",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldDefaultValueSql: "CAST(CAST(GETUTCDATE() AS DATETIMEOFFSET) AT TIME ZONE 'CENTRAL STANDARD TIME (MEXICO)' AS DATETIME)");
        }
    }
}
