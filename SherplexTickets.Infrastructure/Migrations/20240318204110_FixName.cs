using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class FixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Directors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Actors",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Directors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Actors",
                newName: "FullName");
        }
    }
}
