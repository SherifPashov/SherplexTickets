using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class addTheaterManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaterDailyScheduleForMovie_MovieTheater_MovieTheaterId",
                table: "MovieTheaterDailyScheduleForMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheater",
                table: "MovieTheater");

            migrationBuilder.RenameTable(
                name: "MovieTheater",
                newName: "MovieTheaters");

            migrationBuilder.AddColumn<int>(
                name: "TheaterManagerId",
                table: "MovieTheaters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current TheaterManager's Identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TheaterManagars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current ТheaterМanager's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterManagars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheaterManagars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TheaterManagars",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "18702015-42e4-46a9-93db-2dcca0e37703" });

            migrationBuilder.UpdateData(
                table: "MovieTheaters",
                keyColumn: "Id",
                keyValue: 1,
                column: "TheaterManagerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MovieTheaters",
                keyColumn: "Id",
                keyValue: 2,
                column: "TheaterManagerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MovieTheaters",
                keyColumn: "Id",
                keyValue: 3,
                column: "TheaterManagerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MovieTheaters",
                keyColumn: "Id",
                keyValue: 4,
                column: "TheaterManagerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MovieTheaters",
                keyColumn: "Id",
                keyValue: 5,
                column: "TheaterManagerId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaters_TheaterManagerId",
                table: "MovieTheaters",
                column: "TheaterManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterManagars_UserId",
                table: "TheaterManagars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaterDailyScheduleForMovie_MovieTheaters_MovieTheaterId",
                table: "MovieTheaterDailyScheduleForMovie",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_TheaterManagars_TheaterManagerId",
                table: "MovieTheaters",
                column: "TheaterManagerId",
                principalTable: "TheaterManagars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaterDailyScheduleForMovie_MovieTheaters_MovieTheaterId",
                table: "MovieTheaterDailyScheduleForMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_TheaterManagars_TheaterManagerId",
                table: "MovieTheaters");

            migrationBuilder.DropTable(
                name: "TheaterManagars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheaters_TheaterManagerId",
                table: "MovieTheaters");

            migrationBuilder.DropColumn(
                name: "TheaterManagerId",
                table: "MovieTheaters");

            migrationBuilder.RenameTable(
                name: "MovieTheaters",
                newName: "MovieTheater");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheater",
                table: "MovieTheater",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaterDailyScheduleForMovie_MovieTheater_MovieTheaterId",
                table: "MovieTheaterDailyScheduleForMovie",
                column: "MovieTheaterId",
                principalTable: "MovieTheater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
