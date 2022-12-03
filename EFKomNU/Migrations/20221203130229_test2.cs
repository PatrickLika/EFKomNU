using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFKomNU.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KompetenceMedarbejder_MedarbejderEntities_KompetenceListeId1",
                table: "KompetenceMedarbejder");

            migrationBuilder.RenameColumn(
                name: "KompetenceListeId1",
                table: "KompetenceMedarbejder",
                newName: "MedarbejderListeId");

            migrationBuilder.RenameIndex(
                name: "IX_KompetenceMedarbejder_KompetenceListeId1",
                table: "KompetenceMedarbejder",
                newName: "IX_KompetenceMedarbejder_MedarbejderListeId");

            migrationBuilder.AddForeignKey(
                name: "FK_KompetenceMedarbejder_MedarbejderEntities_MedarbejderListeId",
                table: "KompetenceMedarbejder",
                column: "MedarbejderListeId",
                principalTable: "MedarbejderEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KompetenceMedarbejder_MedarbejderEntities_MedarbejderListeId",
                table: "KompetenceMedarbejder");

            migrationBuilder.RenameColumn(
                name: "MedarbejderListeId",
                table: "KompetenceMedarbejder",
                newName: "KompetenceListeId1");

            migrationBuilder.RenameIndex(
                name: "IX_KompetenceMedarbejder_MedarbejderListeId",
                table: "KompetenceMedarbejder",
                newName: "IX_KompetenceMedarbejder_KompetenceListeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_KompetenceMedarbejder_MedarbejderEntities_KompetenceListeId1",
                table: "KompetenceMedarbejder",
                column: "KompetenceListeId1",
                principalTable: "MedarbejderEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
