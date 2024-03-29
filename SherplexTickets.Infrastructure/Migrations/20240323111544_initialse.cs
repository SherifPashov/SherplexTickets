﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class initialse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Actor's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "The current Actor's FirstName")
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
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
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
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The current MovieTheater's Location"),
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
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Movie's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "The current Movie's Title"),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false, comment: "The current Movie's Description"),
                    URLImage = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "The current Movie's URLImage"),
                    YoutubeTrailerUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "The current Movie's YouTube Trailer Url"),
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
                table: "Actors",
                columns: new[] { "Id", "Name" },
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
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Джон Фавро" },
                    { 2, "Джос Уидън" },
                    { 3, "Джеймс Гън" },
                    { 4, "Райън Куглър" },
                    { 5, "Тайка Уайтити" }
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
                table: "MovieTheater",
                columns: new[] { "Id", "ClosingTime", "Contact", "ImageUrl", "Location", "Name", "OpeningTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "029292929", "https://lh3.googleusercontent.com/p/AF1QipMdJrsk_0e4rX4NVGizrakLvwUFBD29M2GLQWNL=s680-w680-h510-rw", "Mall Paradise Center, Хладилника, бул. „Черни връх“ 100, 1407 София", "Cinema City", new DateTime(2024, 3, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "032640111", "https://lh3.googleusercontent.com/p/AF1QipOmXpjzG2b9aPieXQdLPx1d3wis6FwOvEmdHlSr=s680-w680-h510-rw", "Mall of, ж.к. Зона Б-5, бул. „Александър Стамболийски“ 101, 1303 София", "Cinema City", new DateTime(2024, 3, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "024047121", "https://lh3.googleusercontent.com/p/AF1QipOO_ILS0rWgwlCk-Dz3BLpUYBGwniBoAfjs1RGN=s680-w680-h510", "м. Къро, бул. „Цариградско шосе“ 115, 1784 София", "АРЕНА THE MALL", new DateTime(2024, 3, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "024047131", "https://programata.bg/wp-content/uploads/2022/09/arena-grand-mall-varna.jpg", "бул. Владислав Варненчик 186, Mall Varna Варна", "АРЕНА МОЛ ВАРНА", new DateTime(2024, 3, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "024047125", "https://markovotepemall.bg/wp-content/uploads/2020/03/Arena.jpg", "ЦентърПловдив Център, бул. „Руски“ 54, 4000 Пловдив", "Arena IMAX Mall Markovo Tepe Plovdiv", new DateTime(2024, 3, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Duration", "ReleaseDate", "Title", "URLImage", "YoutubeTrailerUrl" },
                values: new object[,]
                {
                    { 1, "\"Iron Man\" представя историята на Тони Старк, гений инженер и милиардер, който живее двойствен живот като супергерой. Филмът разкрива как Тони Старк, след като бива отвлечен и ранен в Афганистан, разработва високотехнологичен брониран костюм, който му позволява да се превърне в Желязният Човек. Той използва този костюм, за да се изправи срещу злодеи и престъпници, като същевременно се бори с вътрешни конфликти и дилеми. Филмът е пълен с екшън и напрежение, като зрителите са изправени пред въпроси за морал, отговорност и справедливост.", 1, 126, new DateTime(2008, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iron Man", "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p170620_p_v8_az.jpg", "https://www.youtube.com/watch?v=8ugaeA-nMTc" },
                    { 2, "В епичния филм \"The Avengers\", Ник Фюри от S.H.I.E.L.D. събира екип от суперхора, за да формира отбора \"Мъстителите\", с цел да помогне за спасяването на Земята от Локи и неговата армия. Локи, братът на Тор и бивш бог на азгардската митология, пристига на Земята със зловещ план за завладяване на света и подчиняване на човечеството.\r\n\r\nФюри, разбирайки сериозността на заплахата, събира най-мощните супергерои от света, включително Желязният Човек (Тони Старк), Капитан Америка (Стив Роджърс), Тор, Хълк (Брус Банър), Блек Уидоу (Наташа Романоф) и Хоукай (Клинт Бартън). Заедно те формират отбора \"Мъстителите\", който трябва да се обедини и да се противопостави на Локи и неговите войски.\r\n\r\nФилмът предлага впечатляваща комбинация от екшън, вълнуващи битки, забавни диалози и емоционални моменти. \"Мъстителите\" не само представя единствено изключителния състав от супергерои, но и демонстрира тяхната способност да работят заедно, дори когато са различни по характери и мотивации.", 2, 143, new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Avengers", "https://fr.web.img3.acsta.net/medias/nmedia/18/85/31/58/20042068.jpg", "https://www.youtube.com/watch?v=eOrNdBpGMv8" },
                    { 3, "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.", 3, 121, new DateTime(2014, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guardians of the Galaxy", "https://m.media-amazon.com/images/M/MV5BNDIzMTk4NDYtMjg5OS00ZGI0LWJhZDYtMzdmZGY1YWU5ZGNkXkEyXkFqcGdeQXVyMTI5NzUyMTIz._V1_.jpg", "https://www.youtube.com/watch?v=d96cjJhvlMA" },
                    { 4, "В \"Черният пантер\" (Black Panther), наследникът на скритото кралство Уаканда, Т'Чала, трябва да изпълни своето предназначение и да въведе своя народ в ново бъдеще, докато се изправя срещу предизвикателство от миналото на своята страна.\r\n\r\nСлед смъртта на баща си, крал Т'Чака, Т'Чала се връща в Уаканда, за да поеме своята правителствена отговорност като новият крал. Той обаче е изправен пред сериозни предизвикателства, когато мистериозния войник Ерик Килмонгър, познат също като Килмонгър, се появява, за да оспори неговото място като правител.\r\n\r\nТ'Чала се изправя срещу вътрешни и външни конфликти, докато се опитва да преодолее препятствията пред Уаканда и да гарантира мира и стабилността на своя народ. Разкрива се сложна интрига, която разкрива теми за власт, наследство и самоопределяне, като Т'Чала трябва да преодолее своите собствени съмнения и грешки, за да стане истинският герой, който Уаканда се нуждае.", 4, 134, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Panther", "https://m.media-amazon.com/images/I/91+GjGet65L._AC_UF894,1000_QL80_.jpg", "https://www.youtube.com/watch?v=xjDjIWPwcPU" },
                    { 5, "В \"Тор: Рагнарок\" (Thor: Ragnarok), Тор е затворен на планетата Сакаар и трябва да се състезава с времето, за да се върне в Асгард и да спре Рагнарок - разрушението на света му, на ръцете на могъщата и безмилостната злодейка Хела.\r\n\r\nСлед като е отведен отнасящата го в Сакаар, Тор се озовава в плен на тиранина Грандмастър, който го принуждава да участва в смъртоносни състезания. В този хаос той открива, че неговият стар враг, братът му Локи, също е в тези нещастия.\r\n\r\nТор и Локи се обединяват, за да победят своя общ враг - Хела, която се оказва могъща асгардианка, бягнала от затвора си, за да поеме контрол над своето родно кралство. Сблъсъкът е неизбежен, а Тор и Локи трябва да обединят силите си с нови съюзници, за да спасят Асгард от сигурната му гибел.", 5, 130, new DateTime(2017, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thor: Ragnarok", "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p12402331_p_v10_ax.jpg", "https://www.youtube.com/watch?v=-mHaq88BAV4" }
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

            migrationBuilder.InsertData(
                table: "MovieTheaterDailyScheduleForMovie",
                columns: new[] { "Id", "Date", "MovieId", "MovieTheaterId", "Price", "ShowTimes" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 17m, "13:30 15:00 17:00 22:30" },
                    { 2, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 17m, "13:30 15:00 17:00 22:30" },
                    { 3, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 17m, "13:30 15:00 17:00 22:30" },
                    { 4, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 17m, "13:30 15:00 17:00 22:30" },
                    { 5, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 17m, "13:30 15:00 17:00 22:30" },
                    { 6, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 17m, "13:30 15:00 17:00 22:30" },
                    { 7, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 17m, "13:30 15:00 17:00 22:30" }
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
                name: "IX_Genres_GenreOfMovieId",
                table: "Genres",
                column: "GenreOfMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresMovies_MovieId",
                table: "GenresMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

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
                name: "GenresMovies");

            migrationBuilder.DropTable(
                name: "MovieTheaterDailyScheduleForMovie");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieTheater");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
