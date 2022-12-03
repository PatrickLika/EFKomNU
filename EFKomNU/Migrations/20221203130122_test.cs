using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFKomNU.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KompetenceEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompetenceEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedarbejderEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tlf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedarbejderEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KompetenceMedarbejder",
                columns: table => new
                {
                    KompetenceListeId = table.Column<int>(type: "int", nullable: false),
                    KompetenceListeId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompetenceMedarbejder", x => new { x.KompetenceListeId, x.KompetenceListeId1 });
                    table.ForeignKey(
                        name: "FK_KompetenceMedarbejder_KompetenceEntities_KompetenceListeId",
                        column: x => x.KompetenceListeId,
                        principalTable: "KompetenceEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KompetenceMedarbejder_MedarbejderEntities_KompetenceListeId1",
                        column: x => x.KompetenceListeId1,
                        principalTable: "MedarbejderEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KompetenceMedarbejder_KompetenceListeId1",
                table: "KompetenceMedarbejder",
                column: "KompetenceListeId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KompetenceMedarbejder");

            migrationBuilder.DropTable(
                name: "KompetenceEntities");

            migrationBuilder.DropTable(
                name: "MedarbejderEntities");
        }
    }
}
