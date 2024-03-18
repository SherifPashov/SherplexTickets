using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class fixDuratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Actor's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "The current Actor's FirstName")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Authot's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Authot's Full Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

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
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreOfBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Movie Genre's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current Movie Genre's Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreOfBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Movie Genre's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current Movie Genre's Name"),
                    GenreOfMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Genres_GenreOfMovieId",
                        column: x => x.GenreOfMovieId,
                        principalTable: "Genres",
                        principalColumn: "Id");
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current Book's Title"),
                    AuthorId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Author Identifier"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "The current Book's Description"),
                    Pages = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Pages Count"),
                    YearPublished = table.Column<int>(type: "int", nullable: false, comment: "The date on which the curent Book was published"),
                    CoverTypeId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's CoverType's Identifier"),
                    ImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "The current Book's cover image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "The current Movie's Title"),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false, comment: "The current Movie's Description"),
                    URLImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The current Movie's URLImage"),
                    DirectorId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Director Identifier"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date on which the curent Movie release"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Movie Watch Time")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
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

            migrationBuilder.CreateTable(
                name: "GenresGenresOfBooks",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresGenresOfBooks", x => new { x.GenreId, x.BookId });
                    table.ForeignKey(
                        name: "FK_GenresGenresOfBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenresGenresOfBooks_GenreOfBooks_GenreId",
                        column: x => x.GenreId,
                        principalTable: "GenreOfBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorsMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie Identifier"),
                    ActorId = table.Column<int>(type: "int", nullable: false, comment: "The current Actor Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsMovies", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
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
                    TicketId = table.Column<int>(type: "int", nullable: false, comment: "The current Ticket's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Ticket's Price"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current Ticket's PurchaseDate"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Робърт Дауни мл." },
                    { 2, "Гуинет Полтроу" },
                    { 3, "Джеф Бриджис" },
                    { 4, "Крис Евънс" },
                    { 5, "Скарлет Йохансън" },
                    { 6, "Марк Ръфало" },
                    { 7, "Крис Прат" },
                    { 8, "Зоуи Салдана" },
                    { 9, "Дейв Батиста" },
                    { 10, "Чедуик Боузман" },
                    { 11, "Майкъл Б. Джордан" },
                    { 12, "Лупита Нионго" },
                    { 13, "Крис Хемсуърт" },
                    { 14, "Том Хидълстън" },
                    { 15, "Кейт Бланшет" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Димитър Димов" },
                    { 2, "Иван Вазов" },
                    { 3, "Паисий Хилендарски" },
                    { 4, "Димитър Талев" },
                    { 5, "Алеко Константинов" }
                });

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Мека" },
                    { 2, "Твърда" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Джон Фавро" },
                    { 2, "Джос Уидън" },
                    { 3, "Джеймс Гън" },
                    { 4, "Райън Куглър" },
                    { 5, "Тайка Уайтити" }
                });

            migrationBuilder.InsertData(
                table: "GenreOfBooks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Художествена литература" },
                    { 2, "Българска литература" },
                    { 3, "Българска класика" },
                    { 4, "Световна класика" },
                    { 5, "Криминален роман" },
                    { 6, "Фантастика" },
                    { 7, "Любовен роман" },
                    { 8, "Исторически роман" },
                    { 9, "Хумористична проза" },
                    { 10, "Роман" },
                    { 11, "Разкази" },
                    { 12, "Поезия" },
                    { 13, "Публицистика" },
                    { 14, "Биографична литература" },
                    { 15, "Биографии" }
                });

            migrationBuilder.InsertData(
                table: "GenreOfBooks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "Автобиографии" },
                    { 17, "Пътеводители" },
                    { 18, "Техническа литература" },
                    { 19, "Образование" },
                    { 20, "Бизнес и Икономика" },
                    { 21, "Кулинария" },
                    { 22, "Диети" },
                    { 23, "Йога" },
                    { 24, "Религия и митология" },
                    { 25, "Философия" },
                    { 26, "Речници и разговорници" },
                    { 27, "Книги на други езици" },
                    { 28, "Детска литература" },
                    { 29, "Хорър" },
                    { 30, "Новели" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreOfMovieId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Екшън" },
                    { 2, null, "Приключенски" },
                    { 3, null, "Комедия" },
                    { 4, null, "Драма" },
                    { 5, null, "Ужаси" },
                    { 6, null, "Фентъзи" },
                    { 7, null, "Научна фантастика" },
                    { 8, null, "Трилър" },
                    { 9, null, "Криминален" },
                    { 10, null, "Документален" },
                    { 11, null, "Романтичен" },
                    { 12, null, "Исторически" },
                    { 13, null, "Военен" },
                    { 14, null, "Анимация" },
                    { 15, null, "Мистерия" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CoverTypeId", "Description", "ImageUrl", "Pages", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, 1, 1, "Романът „Тютюн“ разказва за страстите, сблъсъците и разочарованията на тютюневите фермери в България през края на 19-и началото на 20 век. Главният герой, Тодор Гълъбов, се опитва да се пребори с лошата дола на съдбата и да изгради бъдеще за семейството си в условията на социални и икономически проблеми.", "https://www.musalabooks.bg/image/cache/catalog/IMG_4733-500x650.JPG", 400, "Тютюн", 1951 },
                    { 2, 2, 1, "„Под игото“ е роман от Иван Вазов, който разказва за борбата на българския народ за свобода от османско владичество. Книгата проследява историята на героите в едно село през времето на Априлското въстание.", "https://cdn.ozone.bg/media/catalog/product/cache/1/image/400x498/a4e40ebdc3e371adff845072e1c73f37/p/o/a9bb78972c12abadb60050742887fe9b/pod-igoto-30.jpg", 280, "Под игото", 1888 },
                    { 3, 3, 2, "„История славянобългарска“ е творба на Паисий Хилендарски, която се смята за първата българска историографска книга. В нея се описва историята и културното развитие на българския народ.", "https://cdn.ozone.bg/media/catalog/product/cache/1/image/400x498/a4e40ebdc3e371adff845072e1c73f37/i/s/8357898131e0945b7bb43a6b6e15cee3/istoriya-slavyanobalgarska-uchilishtna-biblioteka---damyan-yakov-30.jpg", 150, "История славянобългарска", 1762 },
                    { 4, 4, 1, "„Железният светилник“ е роман на Димитър Талев, който разказва за историята на едно българско село във времето на Освобождението. Книгата проследява събитията и промените, които преминава селото и неговите обитатели.", "https://hermesbooks.bg/media/catalog/product/cache/e533a3e3438c08fe7c51cedd0cbec189/j/e/jelezniat_svetilnik_hrm_2_20200901160342.jpg", 320, "Железният светилник", 1937 },
                    { 5, 5, 1, "„Бай Ганьо“ е сатиричен роман на Алеко Константинов, който разказва за приключенията на българина Бай Ганьо в ранните години на 20 век. Книгата представлява портрет на типичния българин от тоя период - обаятелен, амбициозен, но и смешен поради своите недостатъци и характеристични черти на поведение.", "https://cdn.ozone.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/a/c5986df39a28a57f97d1598df42c7f45/bay-ganyo-pan-30.jpg", 240, "Бай Ганьо", 1895 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Duration", "ReleaseDate", "Title", "URLImage" },
                values: new object[,]
                {
                    { 1, "\"Iron Man\" представя историята на Тони Старк, гений инженер и милиардер, който живее двойствен живот като супергерой. Филмът разкрива как Тони Старк, след като бива отвлечен и ранен в Афганистан, разработва високотехнологичен брониран костюм, който му позволява да се превърне в Желязният Човек. Той използва този костюм, за да се изправи срещу злодеи и престъпници, като същевременно се бори с вътрешни конфликти и дилеми. Филмът е пълен с екшън и напрежение, като зрителите са изправени пред въпроси за морал, отговорност и справедливост.", 1, 126, new DateTime(2008, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iron Man", "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/80C64C0B63382CD3ED2653356125F275F63D036028A77D38DC3286AD851A6833/scale?width=1200&amp;aspectRatio=1.78&amp;format=webp" },
                    { 2, "В епичния филм \"The Avengers\", Ник Фюри от S.H.I.E.L.D. събира екип от суперхора, за да формира отбора \"Мъстителите\", с цел да помогне за спасяването на Земята от Локи и неговата армия. Локи, братът на Тор и бивш бог на азгардската митология, пристига на Земята със зловещ план за завладяване на света и подчиняване на човечеството.\r\n\r\nФюри, разбирайки сериозността на заплахата, събира най-мощните супергерои от света, включително Желязният Човек (Тони Старк), Капитан Америка (Стив Роджърс), Тор, Хълк (Брус Банър), Блек Уидоу (Наташа Романоф) и Хоукай (Клинт Бартън). Заедно те формират отбора \"Мъстителите\", който трябва да се обедини и да се противопостави на Локи и неговите войски.\r\n\r\nФилмът предлага впечатляваща комбинация от екшън, вълнуващи битки, забавни диалози и емоционални моменти. \"Мъстителите\" не само представя единствено изключителния състав от супергерои, но и демонстрира тяхната способност да работят заедно, дори когато са различни по характери и мотивации.", 2, 143, new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Avengers", "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/B6981BDF339764E6C56626C9DE0820CEF297EAF069F62F244E0F50061219F069/scale?width=1200&aspectRatio=1.78&format=webp" },
                    { 3, "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.", 3, 121, new DateTime(2014, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guardians of the Galaxy", "https://m.media-amazon.com/images/M/MV5BNDIzMTk4NDYtMjg5OS00ZGI0LWJhZDYtMzdmZGY1YWU5ZGNkXkEyXkFqcGdeQXVyMTI5NzUyMTIz._V1_.jpg" },
                    { 4, "В \"Черният пантер\" (Black Panther), наследникът на скритото кралство Уаканда, Т'Чала, трябва да изпълни своето предназначение и да въведе своя народ в ново бъдеще, докато се изправя срещу предизвикателство от миналото на своята страна.\r\n\r\nСлед смъртта на баща си, крал Т'Чака, Т'Чала се връща в Уаканда, за да поеме своята правителствена отговорност като новият крал. Той обаче е изправен пред сериозни предизвикателства, когато мистериозния войник Ерик Килмонгър, познат също като Килмонгър, се появява, за да оспори неговото място като правител.\r\n\r\nТ'Чала се изправя срещу вътрешни и външни конфликти, докато се опитва да преодолее препятствията пред Уаканда и да гарантира мира и стабилността на своя народ. Разкрива се сложна интрига, която разкрива теми за власт, наследство и самоопределяне, като Т'Чала трябва да преодолее своите собствени съмнения и грешки, за да стане истинският герой, който Уаканда се нуждае.", 4, 134, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Panther", "https://m.media-amazon.com/images/I/91+GjGet65L._AC_UF894,1000_QL80_.jpg" },
                    { 5, "В \"Тор: Рагнарок\" (Thor: Ragnarok), Тор е затворен на планетата Сакаар и трябва да се състезава с времето, за да се върне в Асгард и да спре Рагнарок - разрушението на света му, на ръцете на могъщата и безмилостната злодейка Хела.\r\n\r\nСлед като е отведен отнасящата го в Сакаар, Тор се озовава в плен на тиранина Грандмастър, който го принуждава да участва в смъртоносни състезания. В този хаос той открива, че неговият стар враг, братът му Локи, също е в тези нещастия.\r\n\r\nТор и Локи се обединяват, за да победят своя общ враг - Хела, която се оказва могъща асгардианка, бягнала от затвора си, за да поеме контрол над своето родно кралство. Сблъсъкът е неизбежен, а Тор и Локи трябва да обединят силите си с нови съюзници, за да спасят Асгард от сигурната му гибел.", 5, 130, new DateTime(2017, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thor: Ragnarok", "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p12402331_p_v10_ax.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ActorsMovies",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 4 },
                    { 11, 4 },
                    { 12, 4 },
                    { 13, 5 },
                    { 14, 5 },
                    { 15, 5 }
                });

            migrationBuilder.InsertData(
                table: "GenresGenresOfBooks",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 7 },
                    { 5, 9 }
                });

            migrationBuilder.InsertData(
                table: "GenresMovies",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 6, 4 },
                    { 6, 5 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorsMovies_MovieId",
                table: "ActorsMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverTypeId",
                table: "Books",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreOfMovieId",
                table: "Genres",
                column: "GenreOfMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresGenresOfBooks_BookId",
                table: "GenresGenresOfBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresMovies_MovieId",
                table: "GenresMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesMoviesTheaters_MovieTheaterId",
                table: "MoviesMoviesTheaters",
                column: "MovieTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieId",
                table: "Tickets",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsMovies");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookBookStores");

            migrationBuilder.DropTable(
                name: "BookCarts");

            migrationBuilder.DropTable(
                name: "BookReviews");

            migrationBuilder.DropTable(
                name: "GenresGenresOfBooks");

            migrationBuilder.DropTable(
                name: "GenresMovies");

            migrationBuilder.DropTable(
                name: "MoviesMoviesTheaters");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BookStores");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "GenreOfBooks");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MovieTheater");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
