using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class DailySchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesMoviesTheaters");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.CreateTable(
                name: "DailyScheduleMovieTheater",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier"),
                    MovieTheaterId = table.Column<int>(type: "int", nullable: false, comment: "The current MovieTheater's Identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Ticket's Price"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current MovieTheater")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyScheduleMovieTheater", x => new { x.MovieId, x.MovieTheaterId });
                    table.ForeignKey(
                        name: "FK_DailyScheduleMovieTheater_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyScheduleMovieTheater_MovieTheater_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DailyScheduleMovieTheaterMovieId = table.Column<int>(type: "int", nullable: true),
                    DailyScheduleMovieTheaterMovieTheaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowTimes_DailyScheduleMovieTheater_DailyScheduleMovieTheaterMovieId_DailyScheduleMovieTheaterMovieTheaterId",
                        columns: x => new { x.DailyScheduleMovieTheaterMovieId, x.DailyScheduleMovieTheaterMovieTheaterId },
                        principalTable: "DailyScheduleMovieTheater",
                        principalColumns: new[] { "MovieId", "MovieTheaterId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyScheduleMovieTheater_MovieTheaterId",
                table: "DailyScheduleMovieTheater",
                column: "MovieTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_DailyScheduleMovieTheaterMovieId_DailyScheduleMovieTheaterMovieTheaterId",
                table: "ShowTimes",
                columns: new[] { "DailyScheduleMovieTheaterMovieId", "DailyScheduleMovieTheaterMovieTheaterId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowTimes");

            migrationBuilder.DropTable(
                name: "DailyScheduleMovieTheater");

            migrationBuilder.CreateTable(
                name: "MoviesMoviesTheaters",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier"),
                    MovieTheaterId = table.Column<int>(type: "int", nullable: false, comment: "The current MovieTheater's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesMoviesTheaters", x => new { x.MovieId, x.MovieTheaterId });
                    table.ForeignKey(
                        name: "FK_MoviesMoviesTheaters_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesMoviesTheaters_MovieTheater_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Ticket's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier"),
                    TheaterId = table.Column<int>(type: "int", nullable: false, comment: "The current Theater's Identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Ticket's Price"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current Ticket's PurchaseDate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_MovieTheater_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "MovieTheater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesMoviesTheaters_MovieTheaterId",
                table: "MoviesMoviesTheaters",
                column: "MovieTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieId",
                table: "Tickets",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TheaterId",
                table: "Tickets",
                column: "TheaterId");
        }
    }
}
