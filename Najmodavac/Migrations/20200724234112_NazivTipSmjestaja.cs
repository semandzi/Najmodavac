using Microsoft.EntityFrameworkCore.Migrations;

namespace Najmodavac.Migrations
{
    public partial class NazivTipSmjestaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoviSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(maxLength: 255, nullable: false),
                    NazivSmjestajaFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviSmjestaja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NazivViewTipSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipSmjestajaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NazivViewTipSmjestaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NazivViewTipSmjestaja_TipoviSmjestaja_TipSmjestajaId",
                        column: x => x.TipSmjestajaId,
                        principalTable: "TipoviSmjestaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NaziviSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 255, nullable: false),
                    NazivViewTipSmjestajaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaziviSmjestaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaziviSmjestaja_NazivViewTipSmjestaja_NazivViewTipSmjestajaId",
                        column: x => x.NazivViewTipSmjestajaId,
                        principalTable: "NazivViewTipSmjestaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaziviSmjestaja_NazivViewTipSmjestajaId",
                table: "NaziviSmjestaja",
                column: "NazivViewTipSmjestajaId");

            migrationBuilder.CreateIndex(
                name: "IX_NazivViewTipSmjestaja_TipSmjestajaId",
                table: "NazivViewTipSmjestaja",
                column: "TipSmjestajaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoviSmjestaja_NazivSmjestajaFk",
                table: "TipoviSmjestaja",
                column: "NazivSmjestajaFk");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoviSmjestaja_NaziviSmjestaja_NazivSmjestajaFk",
                table: "TipoviSmjestaja",
                column: "NazivSmjestajaFk",
                principalTable: "NaziviSmjestaja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaziviSmjestaja_NazivViewTipSmjestaja_NazivViewTipSmjestajaId",
                table: "NaziviSmjestaja");

            migrationBuilder.DropTable(
                name: "NazivViewTipSmjestaja");

            migrationBuilder.DropTable(
                name: "TipoviSmjestaja");

            migrationBuilder.DropTable(
                name: "NaziviSmjestaja");
        }
    }
}
