using Microsoft.EntityFrameworkCore.Migrations;

namespace Najmodavac.Migrations
{
    public partial class ProsirivanjeTipaSmjestaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojSmjestajnihJedinica",
                table: "TipoviSmjestaja",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "TipoviSmjestaja",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostanskiBroj",
                table: "TipoviSmjestaja",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ulica",
                table: "TipoviSmjestaja",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojSmjestajnihJedinica",
                table: "TipoviSmjestaja");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "TipoviSmjestaja");

            migrationBuilder.DropColumn(
                name: "PostanskiBroj",
                table: "TipoviSmjestaja");

            migrationBuilder.DropColumn(
                name: "Ulica",
                table: "TipoviSmjestaja");
        }
    }
}
