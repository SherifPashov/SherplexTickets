using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class ChangeGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Genres_GenreOfMovieId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GenreOfMovieId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GenreOfMovieId",
                table: "Genres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreOfMovieId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreOfMovieId",
                table: "Genres",
                column: "GenreOfMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Genres_GenreOfMovieId",
                table: "Genres",
                column: "GenreOfMovieId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
