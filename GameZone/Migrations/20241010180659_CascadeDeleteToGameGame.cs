using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    public partial class CascadeDeleteToGameGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames");

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames",
                column: "GamerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames");

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames",
                column: "GamerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
