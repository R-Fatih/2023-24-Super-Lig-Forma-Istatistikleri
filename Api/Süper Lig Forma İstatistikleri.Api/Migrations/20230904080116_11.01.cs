using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Süper_Lig_Forma_İstatistikleri.Api.Migrations
{
    /// <inheritdoc />
    public partial class _1101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsKeeper",
                table: "Jersey",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsKeeper",
                table: "Jersey");
        }
    }
}
