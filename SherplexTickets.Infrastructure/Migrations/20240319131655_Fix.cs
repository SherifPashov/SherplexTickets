using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "URLImage",
                value: "https://fr.web.img3.acsta.net/medias/nmedia/18/85/31/58/20042068.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "URLImage",
                value: "https://m.media-amazon.com/images/I/71Sb4AfzGTL._AC_UF894,1000_QL80_.jpg");
        }
    }
}
