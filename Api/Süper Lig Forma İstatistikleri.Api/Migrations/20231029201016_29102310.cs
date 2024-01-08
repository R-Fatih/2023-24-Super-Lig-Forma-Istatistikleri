using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Süper_Lig_Forma_İstatistikleri.Api.Migrations
{
    /// <inheritdoc />
    public partial class _29102310 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "Match");
        }
    }
}
