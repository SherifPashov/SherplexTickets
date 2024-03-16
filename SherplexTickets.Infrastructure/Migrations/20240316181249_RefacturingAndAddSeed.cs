using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class RefacturingAndAddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishingHouse",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "The current Movie Genre's Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "The current Genre's Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                comment: "The current Movie Genre's Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Genre's Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GenreOfMovieId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Book's Author Identifier");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
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
                    { 15, "Биографии" },
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
                columns: new[] { "Id", "GenreOfMovieId", "MovieId", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Екшън" },
                    { 2, null, null, "Приключенски" },
                    { 3, null, null, "Комедия" },
                    { 4, null, null, "Драма" },
                    { 5, null, null, "Ужаси" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreOfMovieId", "MovieId", "Name" },
                values: new object[,]
                {
                    { 6, null, null, "Фентъзи" },
                    { 7, null, null, "Научна фантастика" },
                    { 8, null, null, "Трилър" },
                    { 9, null, null, "Криминален" },
                    { 10, null, null, "Документален" },
                    { 11, null, null, "Романтичен" },
                    { 12, null, null, "Исторически" },
                    { 13, null, null, "Военен" },
                    { 14, null, null, "Анимация" },
                    { 15, null, null, "Мистерия" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CoverTypeId", "Description", "ImageUrl", "Pages", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, 1, 1, "Романът „Тютюн“ разказва за страстите, сблъсъците и разочарованията на тютюневите фермери в България през края на 19-и началото на 20 век. Главният герой, Тодор Гълъбов, се опитва да се пребори с лошата дола на съдбата и да изгради бъдеще за семейството си в условията на социални и икономически проблеми.", "@---", 400, "Тютюн", 1951 },
                    { 2, 2, 1, "„Под игото“ е роман от Иван Вазов, който разказва за борбата на българския народ за свобода от османско владичество. Книгата проследява историята на героите в едно село през времето на Априлското въстание.", "@---", 280, "Под игото", 1888 },
                    { 3, 3, 2, "„История славянобългарска“ е творба на Паисий Хилендарски, която се смята за първата българска историографска книга. В нея се описва историята и културното развитие на българския народ.", "@---", 150, "История славянобългарска", 1762 },
                    { 4, 4, 1, "„Железният светилник“ е роман на Димитър Талев, който разказва за историята на едно българско село във времето на Освобождението. Книгата проследява събитията и промените, които преминава селото и неговите обитатели.", "@---", 320, "Железният светилник", 1937 },
                    { 5, 5, 1, "„Бай Ганьо“ е сатиричен роман на Алеко Константинов, който разказва за приключенията на българина Бай Ганьо в ранните години на 20 век. Книгата представлява портрет на типичния българин от тоя период - обаятелен, амбициозен, но и смешен поради своите недостатъци и характеристични черти на поведение.", "@---", 240, "Бай Ганьо", 1895 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreOfMovieId",
                table: "Genres",
                column: "GenreOfMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MovieId",
                table: "Genres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresGenresOfBooks_BookId",
                table: "GenresGenresOfBooks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Genres_GenreOfMovieId",
                table: "Genres",
                column: "GenreOfMovieId",
                principalTable: "Genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_MovieId",
                table: "Genres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Genres_GenreOfMovieId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MovieId",
                table: "Genres");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "GenresGenresOfBooks");

            migrationBuilder.DropTable(
                name: "GenreOfBooks");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GenreOfMovieId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MovieId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "GenreOfMovieId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "The current Genre's Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "The current Movie Genre's Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                comment: "The current Genre's Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Movie Genre's Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                comment: "The current Book's Author");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Book's Genre's Identifier");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "The current Book's Price");

            migrationBuilder.AddColumn<string>(
                name: "PublishingHouse",
                table: "Books",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                comment: "The current Book's Publishing House");

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
