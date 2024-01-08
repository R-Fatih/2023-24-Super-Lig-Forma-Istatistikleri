using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Süper_Lig_Forma_İstatistikleri.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jersey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shorts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jersey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jersey_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamJerseyId = table.Column<int>(type: "int", nullable: true),
                    RefereeJerseyId = table.Column<int>(type: "int", nullable: true),
                    AwayTeamJerseyId = table.Column<int>(type: "int", nullable: true),
                    HomeMS = table.Column<int>(type: "int", nullable: true),
                    AwayMS = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Jersey_AwayTeamJerseyId",
                        column: x => x.AwayTeamJerseyId,
                        principalTable: "Jersey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Jersey_HomeTeamJerseyId",
                        column: x => x.HomeTeamJerseyId,
                        principalTable: "Jersey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Jersey_RefereeJerseyId",
                        column: x => x.RefereeJerseyId,
                        principalTable: "Jersey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Team_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jersey_TeamId",
                table: "Jersey",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamId",
                table: "Match",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamJerseyId",
                table: "Match",
                column: "AwayTeamJerseyId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamId",
                table: "Match",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamJerseyId",
                table: "Match",
                column: "HomeTeamJerseyId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeJerseyId",
                table: "Match",
                column: "RefereeJerseyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Jersey");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
