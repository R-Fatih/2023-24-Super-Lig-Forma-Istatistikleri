using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Süper_Lig_Forma_İstatistikleri.Api.Migrations
{
    /// <inheritdoc />
    public partial class _2219 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeTeamGKId",
                table: "Match",
                newName: "HomeTeamJerseyGKId");

            migrationBuilder.RenameColumn(
                name: "AwayTeamGKId",
                table: "Match",
                newName: "AwayTeamJerseyGKId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamJerseyGKId",
                table: "Match",
                column: "AwayTeamJerseyGKId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamJerseyGKId",
                table: "Match",
                column: "HomeTeamJerseyGKId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Jersey_AwayTeamJerseyGKId",
                table: "Match",
                column: "AwayTeamJerseyGKId",
                principalTable: "Jersey",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Jersey_HomeTeamJerseyGKId",
                table: "Match",
                column: "HomeTeamJerseyGKId",
                principalTable: "Jersey",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Jersey_AwayTeamJerseyGKId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Jersey_HomeTeamJerseyGKId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_AwayTeamJerseyGKId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_HomeTeamJerseyGKId",
                table: "Match");

            migrationBuilder.RenameColumn(
                name: "HomeTeamJerseyGKId",
                table: "Match",
                newName: "HomeTeamGKId");

            migrationBuilder.RenameColumn(
                name: "AwayTeamJerseyGKId",
                table: "Match",
                newName: "AwayTeamGKId");
        }
    }
}
