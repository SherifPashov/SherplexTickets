using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class YouTubeurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "URLImage",
                table: "Movies",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                comment: "The current Movie's URLImage",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "The current Movie's URLImage");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeTrailerUrl",
                table: "Movies",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                comment: "The current Movie's YouTube Trailer Url");

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), "029292929", new DateTime(2024, 3, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), "032640111", new DateTime(2024, 3, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), "024047121", new DateTime(2024, 3, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), "024047131", new DateTime(2024, 3, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), "024047125", new DateTime(2024, 3, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "YoutubeTrailerUrl",
                value: "https://www.youtube.com/watch?v=8ugaeA-nMTc");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "YoutubeTrailerUrl",
                value: "https://www.youtube.com/watch?v=eOrNdBpGMv8");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "YoutubeTrailerUrl",
                value: "https://www.youtube.com/watch?v=d96cjJhvlMA");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "YoutubeTrailerUrl",
                value: "https://www.youtube.com/watch?v=xjDjIWPwcPU");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "YoutubeTrailerUrl",
                value: "https://www.youtube.com/watch?v=v7MGUNV8MxU&t=1s");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeTrailerUrl",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "URLImage",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                comment: "The current Movie's URLImage",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldComment: "The current Movie's URLImage");

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 929 2929", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "032 640 111", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 4047 121", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 4047 131", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClosingTime", "Contact", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 4047 125", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
