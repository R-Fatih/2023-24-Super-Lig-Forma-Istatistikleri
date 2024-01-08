using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Süper_Lig_Forma_İstatistikleri.Api.Migrations
{
    /// <inheritdoc />
    public partial class _1105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainId",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainId",
                table: "Match");
        }
    }
}
