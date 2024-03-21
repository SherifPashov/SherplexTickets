using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class DailySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyScheduleMovieTheater",
                table: "DailyScheduleMovieTheater");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DailyScheduleMovieTheater",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current DailyScheduleMovieTheater's Identifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ShowTimes",
                table: "DailyScheduleMovieTheater",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyScheduleMovieTheater",
                table: "DailyScheduleMovieTheater",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "YoutubeTrailerUrl",
                value: "https://www.youtube.com/watch?v=-mHaq88BAV4");

            migrationBuilder.CreateIndex(
                name: "IX_DailyScheduleMovieTheater_MovieId",
                table: "DailyScheduleMovieTheater",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyScheduleMovieTheater",
                table: "DailyScheduleMovieTheater");

            migrationBuilder.DropIndex(
                name: "IX_DailyScheduleMovieTheater_MovieId",
                table: "DailyScheduleMovieTheater");

            migrationBuilder.DeleteData(
                table: "DailyScheduleMovieTheater",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyScheduleMovieTheater",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyScheduleMovieTheater",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DailyScheduleMovieTheater",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DailyScheduleMovieTheater");

            migrationBuilder.DropColumn(
                name: "ShowTimes",
                table: "DailyScheduleMovieTheater");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyScheduleMovieTheater",
                table: "DailyScheduleMovieTheater",
                columns: new[] { "MovieId", "MovieTheaterId" });

            migrationBuilder.CreateTable(
                name: "ShowTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyScheduleMovieTheaterMovieId = table.Column<int>(type: "int", nullable: true),
                    DailyScheduleMovieTheaterMovieTheaterId = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "YoutubeTrailerUrl",
                value: "https://www.youtube.com/watch?v=v7MGUNV8MxU&t=1s");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_DailyScheduleMovieTheaterMovieId_DailyScheduleMovieTheaterMovieTheaterId",
                table: "ShowTimes",
                columns: new[] { "DailyScheduleMovieTheaterMovieId", "DailyScheduleMovieTheaterMovieTheaterId" });
        }
    }
}
