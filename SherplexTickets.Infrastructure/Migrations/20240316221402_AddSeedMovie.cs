using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherplexTickets.Infrastructure.Migrations
{
    public partial class AddSeedMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Authors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The current Authot's Full Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Authors",
                type: "int",
                nullable: false,
                comment: "The current Authot's Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Actors",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "The current Actor's FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldComment: "The current Actor's FirstName");

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
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "MovieWhatchTime", "Title", "URLImage", "YearPublished" },
                values: new object[,]
                {
                    { 1, "\"Iron Man\" представя историята на Тони Старк, гений инженер и милиардер, който живее двойствен живот като супергерой. Филмът разкрива как Тони Старк, след като бива отвлечен и ранен в Афганистан, разработва високотехнологичен брониран костюм, който му позволява да се превърне в Желязният Човек. Той използва този костюм, за да се изправи срещу злодеи и престъпници, като същевременно се бори с вътрешни конфликти и дилеми. Филмът е пълен с екшън и напрежение, като зрителите са изправени пред въпроси за морал, отговорност и справедливост.", 1, 126, "Iron Man", "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/80C64C0B63382CD3ED2653356125F275F63D036028A77D38DC3286AD851A6833/scale?width=1200&amp;aspectRatio=1.78&amp;format=webp", new DateTime(2008, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "В епичния филм \"The Avengers\", Ник Фюри от S.H.I.E.L.D. събира екип от суперхора, за да формира отбора \"Мъстителите\", с цел да помогне за спасяването на Земята от Локи и неговата армия. Локи, братът на Тор и бивш бог на азгардската митология, пристига на Земята със зловещ план за завладяване на света и подчиняване на човечеството.\r\n\r\nФюри, разбирайки сериозността на заплахата, събира най-мощните супергерои от света, включително Желязният Човек (Тони Старк), Капитан Америка (Стив Роджърс), Тор, Хълк (Брус Банър), Блек Уидоу (Наташа Романоф) и Хоукай (Клинт Бартън). Заедно те формират отбора \"Мъстителите\", който трябва да се обедини и да се противопостави на Локи и неговите войски.\r\n\r\nФилмът предлага впечатляваща комбинация от екшън, вълнуващи битки, забавни диалози и емоционални моменти. \"Мъстителите\" не само представя единствено изключителния състав от супергерои, но и демонстрира тяхната способност да работят заедно, дори когато са различни по характери и мотивации.", 2, 143, "The Avengers", "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/B6981BDF339764E6C56626C9DE0820CEF297EAF069F62F244E0F50061219F069/scale?width=1200&aspectRatio=1.78&format=webp", new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.", 3, 121, "Guardians of the Galaxy", "https://m.media-amazon.com/images/M/MV5BNDIzMTk4NDYtMjg5OS00ZGI0LWJhZDYtMzdmZGY1YWU5ZGNkXkEyXkFqcGdeQXVyMTI5NzUyMTIz._V1_.jpg", new DateTime(2014, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "В \"Черният пантер\" (Black Panther), наследникът на скритото кралство Уаканда, Т'Чала, трябва да изпълни своето предназначение и да въведе своя народ в ново бъдеще, докато се изправя срещу предизвикателство от миналото на своята страна.\r\n\r\nСлед смъртта на баща си, крал Т'Чака, Т'Чала се връща в Уаканда, за да поеме своята правителствена отговорност като новият крал. Той обаче е изправен пред сериозни предизвикателства, когато мистериозния войник Ерик Килмонгър, познат също като Килмонгър, се появява, за да оспори неговото място като правител.\r\n\r\nТ'Чала се изправя срещу вътрешни и външни конфликти, докато се опитва да преодолее препятствията пред Уаканда и да гарантира мира и стабилността на своя народ. Разкрива се сложна интрига, която разкрива теми за власт, наследство и самоопределяне, като Т'Чала трябва да преодолее своите собствени съмнения и грешки, за да стане истинският герой, който Уаканда се нуждае.", 4, 134, "Black Panther", "https://m.media-amazon.com/images/I/91+GjGet65L._AC_UF894,1000_QL80_.jpg", new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "В \"Тор: Рагнарок\" (Thor: Ragnarok), Тор е затворен на планетата Сакаар и трябва да се състезава с времето, за да се върне в Асгард и да спре Рагнарок - разрушението на света му, на ръцете на могъщата и безмилостната злодейка Хела.\r\n\r\nСлед като е отведен отнасящата го в Сакаар, Тор се озовава в плен на тиранина Грандмастър, който го принуждава да участва в смъртоносни състезания. В този хаос той открива, че неговият стар враг, братът му Локи, също е в тези нещастия.\r\n\r\nТор и Локи се обединяват, за да победят своя общ враг - Хела, която се оказва могъща асгардианка, бягнала от затвора си, за да поеме контрол над своето родно кралство. Сблъсъкът е неизбежен, а Тор и Локи трябва да обединят силите си с нови съюзници, за да спасят Асгард от сигурната му гибел.", 5, 130, "Thor: Ragnarok", "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p12402331_p_v10_ax.jpg", new DateTime(2017, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "GenresMovies",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Authors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The current Authot's Full Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Authors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Authot's Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Actors",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                comment: "The current Actor's FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "The current Actor's FirstName");
        }
    }
}
