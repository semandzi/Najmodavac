using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Najmodavac.Migrations
{
    public partial class RezervacijeAndSmjestajnaJedinica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: false),
                    Grad = table.Column<string>(nullable: false),
                    Drzava = table.Column<string>(nullable: false),
                    PocetakRezervacije = table.Column<DateTime>(nullable: false),
                    KrajRezervacije = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmjestajnaJedinica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Velicina = table.Column<string>(maxLength: 5, nullable: false),
                    Znacajke = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Cijena = table.Column<int>(nullable: false),
                    NazivSmjestajaFk = table.Column<int>(nullable: false),
                    TipSmjestajaFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmjestajnaJedinica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmjestajnaJedinica_NaziviSmjestaja_NazivSmjestajaFk",
                        column: x => x.NazivSmjestajaFk,
                        principalTable: "NaziviSmjestaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SmjestajnaJedinica_TipoviSmjestaja_TipSmjestajaFk",
                        column: x => x.TipSmjestajaFk,
                        principalTable: "TipoviSmjestaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmjestajnaJedinica_NazivSmjestajaFk",
                table: "SmjestajnaJedinica",
                column: "NazivSmjestajaFk");

            migrationBuilder.CreateIndex(
                name: "IX_SmjestajnaJedinica_TipSmjestajaFk",
                table: "SmjestajnaJedinica",
                column: "TipSmjestajaFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "SmjestajnaJedinica");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
