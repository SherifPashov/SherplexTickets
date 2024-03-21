using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyScheduleMovieTheater");

            migrationBuilder.CreateTable(
                name: "MovieTheaterDailyScheduleForMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current DailyScheduleMovieTheater's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier"),
                    MovieTheaterId = table.Column<int>(type: "int", nullable: false, comment: "The current MovieTheater's Identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Ticket's Price"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current MovieTheater"),
                    ShowTimes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheaterDailyScheduleForMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTheaterDailyScheduleForMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTheaterDailyScheduleForMovie_MovieTheater_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MovieTheaterDailyScheduleForMovie",
                columns: new[] { "Id", "Date", "MovieId", "MovieTheaterId", "Price", "ShowTimes" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 17m, "13:30, 15:00, 17:00, 22:30" },
                    { 2, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 17m, "13:30, 15:00, 17:00, 22:30" },
                    { 3, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 17m, "13:30, 15:00, 17:00, 22:30" },
                    { 4, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 17m, "13:30, 15:00, 17:00, 22:30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaterDailyScheduleForMovie_MovieId",
                table: "MovieTheaterDailyScheduleForMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaterDailyScheduleForMovie_MovieTheaterId",
                table: "MovieTheaterDailyScheduleForMovie",
                column: "MovieTheaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTheaterDailyScheduleForMovie");

            migrationBuilder.CreateTable(
                name: "DailyScheduleMovieTheater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current DailyScheduleMovieTheater's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier"),
                    MovieTheaterId = table.Column<int>(type: "int", nullable: false, comment: "The current MovieTheater's Identifier"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current MovieTheater"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Ticket's Price"),
                    ShowTimes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyScheduleMovieTheater", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "DailyScheduleMovieTheater",
                columns: new[] { "Id", "Date", "MovieId", "MovieTheaterId", "Price", "ShowTimes" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 17m, "13:30, 15:00, 17:00, 22:30" },
                    { 2, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 17m, "13:30, 15:00, 17:00, 22:30" },
                    { 3, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 17m, "13:30, 15:00, 17:00, 22:30" },
                    { 4, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 17m, "13:30, 15:00, 17:00, 22:30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyScheduleMovieTheater_MovieId",
                table: "DailyScheduleMovieTheater",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyScheduleMovieTheater_MovieTheaterId",
                table: "DailyScheduleMovieTheater",
                column: "MovieTheaterId");
        }
    }
}
