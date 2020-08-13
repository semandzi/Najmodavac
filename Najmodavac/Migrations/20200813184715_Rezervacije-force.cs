using Microsoft.EntityFrameworkCore.Migrations;

namespace Najmodavac.Migrations
{
    public partial class Rezervacijeforce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SmjestajnaJedinicaFk",
                table: "Rezervacije",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_SmjestajnaJedinicaFk",
                table: "Rezervacije",
                column: "SmjestajnaJedinicaFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_SmjestajnaJedinica_SmjestajnaJedinicaFk",
                table: "Rezervacije",
                column: "SmjestajnaJedinicaFk",
                principalTable: "SmjestajnaJedinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_SmjestajnaJedinica_SmjestajnaJedinicaFk",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_SmjestajnaJedinicaFk",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "SmjestajnaJedinicaFk",
                table: "Rezervacije");
        }
    }
}
