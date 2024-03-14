using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MovieID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MovieID",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateViewed",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Comments",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieID",
                table: "Comments",
                newName: "IX_Comments_MovieId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                comment: "The current Ticket's PurchaseDate",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The current Ticket's Price",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Tickets",
                type: "int",
                nullable: false,
                comment: "The current Movie's Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Tickets",
                type: "int",
                nullable: false,
                comment: "The current Ticket's Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "URLImage",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                comment: "The current Movie's URLImage",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "The current Movie's Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MovieWhatchTime",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                comment: "The current Movie's Movie Watch Time",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                comment: "The current Movie's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Movies",
                type: "int",
                nullable: false,
                comment: "The current Movie's Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateViewedMovie",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The date on which the movie will be watched");

            migrationBuilder.AddColumn<DateTime>(
                name: "YearPublished",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The date on which the curent Movie was published");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The current Genre's Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                comment: "The current Genre's Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The current User's Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Comments",
                type: "int",
                nullable: false,
                comment: "The current Movie's Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Movie Review's Identifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Comments",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                comment: "The current Movie Review's Description");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Movie Review's Rate");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The current Movie Review's Title");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ActorsMovies",
                type: "int",
                nullable: false,
                comment: "The current Movie Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "ActorsMovies",
                type: "int",
                nullable: false,
                comment: "The current Actor Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                comment: "The current Actor's LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The current Actor's FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Actors",
                type: "int",
                nullable: false,
                comment: "The current Actor's Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current BookStore's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current BookStore's Name"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current BookStore's Location"),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The current BookStore's Mobile Contact"),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current BookStore's Opening Time"),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current BookStore's Closing Time"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The current BookStore's Image Url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current CoverType's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The current CoverType's Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesMovieID });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesMovieID",
                        column: x => x.MoviesMovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenresMovies",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false, comment: "The current Genre's Identifier"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresMovies", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_GenresMovies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenresMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTheater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current MovieTheater's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current MovieTheater's Name"),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The current MovieTheater's Location"),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The current MovieTheater's Mobile Contact"),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current MovieTheater's Opening Time"),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current MovieTheater's Closing Time"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The current MovieTheater's Image Url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheater", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current Book's Title"),
                    Author = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current Book's Author"),
                    GenreId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Genre's Identifier"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "The current Book's Description"),
                    Pages = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Pages Count"),
                    PublishingHouse = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current Book's Publishing House"),
                    YearPublished = table.Column<int>(type: "int", nullable: false, comment: "The date on which the curent Book was published"),
                    CoverTypeId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's CoverType's Identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The current Book's Price"),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The current Book's cover image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesMoviesTheaters_MovieTheater_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBookStores",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    BookStoreId = table.Column<int>(type: "int", nullable: false, comment: "The current BookStore's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookStores", x => new { x.BookId, x.BookStoreId });
                    table.ForeignKey(
                        name: "FK_BookBookStores_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookStores_BookStores_BookStoreId",
                        column: x => x.BookStoreId,
                        principalTable: "BookStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCarts",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    CartId = table.Column<int>(type: "int", nullable: false, comment: "The current Cart's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCarts", x => new { x.BookId, x.CartId });
                    table.ForeignKey(
                        name: "FK_BookCarts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Book Review's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "The current Book Review's Title"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "The current Book Review's Description"),
                    Rate = table.Column<int>(type: "int", nullable: false, comment: "The current Book Review's Rate"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBookStores_BookStoreId",
                table: "BookBookStores",
                column: "BookStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCarts_CartId",
                table: "BookCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_UserId",
                table: "BookReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverTypeId",
                table: "Books",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesMovieID",
                table: "GenreMovie",
                column: "MoviesMovieID");

            migrationBuilder.CreateIndex(
                name: "IX_GenresMovies_MovieId",
                table: "GenresMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesMoviesTheaters_MovieTheaterId",
                table: "MoviesMoviesTheaters",
                column: "MovieTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "BookBookStores");

            migrationBuilder.DropTable(
                name: "BookCarts");

            migrationBuilder.DropTable(
                name: "BookReviews");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "GenresMovies");

            migrationBuilder.DropTable(
                name: "MoviesMoviesTheaters");

            migrationBuilder.DropTable(
                name: "BookStores");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "MovieTheater");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateViewedMovie",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "YearPublished",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Comments",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                newName: "IX_Comments_MovieID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The current Ticket's PurchaseDate");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The current Ticket's Price");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Movie's Identifier");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Ticket's Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "URLImage",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "The current Movie's URLImage");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "The current Movie's Title");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MovieWhatchTime",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The current Movie's Movie Watch Time");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldComment: "The current Movie's Description");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Movie's Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateViewed",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The current Genre's Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Genre's Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The current User's Identifier");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Movie's Identifier");

            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Comments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ActorsMovies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Movie Identifier");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "ActorsMovies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Actor Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "The current Actor's LastName");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The current Actor's FirstName");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Actors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Actor's Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MovieID",
                table: "Genres",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieID",
                table: "Comments",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_MovieID",
                table: "Genres",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID");
        }
    }
}
