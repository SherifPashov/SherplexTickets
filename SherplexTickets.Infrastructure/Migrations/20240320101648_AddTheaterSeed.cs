using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class AddTheaterSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Theater's Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "MovieTheater",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "The current MovieTheater's Location",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "The current MovieTheater's Location");

            migrationBuilder.InsertData(
                table: "MovieTheater",
                columns: new[] { "Id", "ClosingTime", "Contact", "ImageUrl", "Location", "Name", "OpeningTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 929 2929", "https://lh3.googleusercontent.com/p/AF1QipMdJrsk_0e4rX4NVGizrakLvwUFBD29M2GLQWNL=s680-w680-h510-rw", "Mall Paradise Center, Хладилника, бул. „Черни връх“ 100, 1407 София", "Cinema City", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "032 640 111", "https://lh3.googleusercontent.com/p/AF1QipOmXpjzG2b9aPieXQdLPx1d3wis6FwOvEmdHlSr=s680-w680-h510-rw", "Mall of, ж.к. Зона Б-5, бул. „Александър Стамболийски“ 101, 1303 София", "Cinema City", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 4047 121", "https://lh3.googleusercontent.com/p/AF1QipOO_ILS0rWgwlCk-Dz3BLpUYBGwniBoAfjs1RGN=s680-w680-h510", "м. Къро, бул. „Цариградско шосе“ 115, 1784 София", "АРЕНА THE MALL", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 4047 131", "https://programata.bg/wp-content/uploads/2022/09/arena-grand-mall-varna.jpg", "бул. Владислав Варненчик 186, Mall Varna Варна", "АРЕНА МОЛ ВАРНА", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "02 4047 125", "https://markovotepemall.bg/wp-content/uploads/2020/03/Arena.jpg", "ЦентърПловдив Център, бул. „Руски“ 54, 4000 Пловдив", "Arena IMAX Mall Markovo Tepe Plovdiv", new DateTime(2024, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TheaterId",
                table: "Tickets",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MovieTheater_TheaterId",
                table: "Tickets",
                column: "TheaterId",
                principalTable: "MovieTheater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MovieTheater_TheaterId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TheaterId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieTheater",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "MovieTheater",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "The current MovieTheater's Location",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "The current MovieTheater's Location");
        }
    }
}
