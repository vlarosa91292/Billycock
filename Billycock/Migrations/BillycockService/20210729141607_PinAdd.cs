using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations.BillycockService
{
    public partial class PinAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pin",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pin",
                table: "USUARIO");
        }
    }
}
