using SherplexTickets.Infrastructure.Data.Models.Books;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data.DataSeeding
{
    internal class DataSeed
    {
        public DataSeed()
        {
            GenresOfBooks = SeedGenresOfBook();
            CoverTypes = SeedCoverTypes();
            Authors = SeedAuthor();
            Books = SeedBooks();
            GenresGenresOfBooks = SeedGenresGenresOfBooks();

            Directors = SeedDirectors();
            GenresOfMovies = SeedGenresOfMovie();
            Actors = SeedActors();
            Movies = SeedMovies();
            ActorsMovies = SeedActorMovies();
            GenresGenreOfMovies = SeedGenreGenresOfMovie();

        }
        //Book
        public IEnumerable<GenreOfBook> GenresOfBooks { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<CoverType> CoverTypes { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<GenreGenreOfBook> GenresGenresOfBooks { get; set; }


        //Movie
        public IEnumerable<Director> Directors { get; set; }
        public IEnumerable<GenreOfMovie> GenresOfMovies { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<ActorMovie> ActorsMovies { get; set; }
        public IEnumerable<GenreGenreOfMovie> GenresGenreOfMovies { get; set; }

        
        private IEnumerable<GenreOfBook> SeedGenresOfBook()
        {
            return new List<GenreOfBook>()
            {
                new GenreOfBook { Id = 1, Name = "Художествена литература" },
                new GenreOfBook { Id = 2, Name = "Българска литература" },
                new GenreOfBook { Id = 3, Name = "Българска класика" },
                new GenreOfBook { Id = 4, Name = "Световна класика" },
                new GenreOfBook { Id = 5, Name = "Криминален роман" },
                new GenreOfBook { Id = 6, Name = "Фантастика" },
                new GenreOfBook { Id = 7, Name = "Любовен роман" },
                new GenreOfBook { Id = 8, Name = "Исторически роман" },
                new GenreOfBook { Id = 9, Name = "Хумористична проза" },
                new GenreOfBook { Id = 10, Name = "Роман" },
                new GenreOfBook { Id = 11, Name = "Разкази" },
                new GenreOfBook { Id = 12, Name = "Поезия" },
                new GenreOfBook { Id = 13, Name = "Публицистика" },
                new GenreOfBook { Id = 14, Name = "Биографична литература" },
                new GenreOfBook { Id = 15, Name = "Биографии" },
                new GenreOfBook { Id = 16, Name = "Автобиографии" },
                new GenreOfBook { Id = 17, Name = "Пътеводители" },
                new GenreOfBook { Id = 18, Name = "Техническа литература" },
                new GenreOfBook { Id = 19, Name = "Образование" },
                new GenreOfBook { Id = 20, Name = "Бизнес и Икономика" },
                new GenreOfBook { Id = 21, Name = "Кулинария" },
                new GenreOfBook { Id = 22, Name = "Диети" },
                new GenreOfBook { Id = 23, Name = "Йога" },
                new GenreOfBook { Id = 24, Name = "Религия и митология" },
                new GenreOfBook { Id = 25, Name = "Философия" },
                new GenreOfBook { Id = 26, Name = "Речници и разговорници" },
                new GenreOfBook { Id = 27, Name = "Книги на други езици" },
                new GenreOfBook { Id = 28, Name = "Детска литература" },
                new GenreOfBook { Id = 29, Name = "Хорър" },
                new GenreOfBook { Id = 30, Name = "Новели" }
            };
        }

        private IEnumerable<CoverType> SeedCoverTypes()
        {
            return new List<CoverType>
            {
                new CoverType { Id = 1, Name = "Мека" },
                new CoverType { Id = 2, Name = "Твърда" }

            };

        }
        private IEnumerable<Author> SeedAuthor()
        {
            return new List<Author>
            {
                new Author { Id = 1,FullName = "Димитър Димов"},
                new Author { Id = 2,FullName = "Иван Вазов"},
                new Author { Id = 3,FullName = "Паисий Хилендарски"},
                new Author { Id = 4,FullName = "Димитър Талев"},
                new Author { Id = 5,FullName = "Алеко Константинов"},
            };
        }
        private IEnumerable<Book> SeedBooks()
        {
            return new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Тютюн",
                    AuthorId = 1,
                    Description = "Романът „Тютюн“ разказва за страстите, сблъсъците и разочарованията на тютюневите фермери в България през края на 19-и началото на 20 век. Главният герой, Тодор Гълъбов, се опитва да се пребори с лошата дола на съдбата и да изгради бъдеще за семейството си в условията на социални и икономически проблеми.",
                    Pages = 400,
                    YearPublished = 1951,
                    CoverTypeId = 1,
                    ImageUrl = "https://www.musalabooks.bg/image/cache/catalog/IMG_4733-500x650.JPG",

                },
                new Book()
                {
                    Id = 2,
                    Title = "Под игото",
                    AuthorId = 2,
                    Description = "„Под игото“ е роман от Иван Вазов, който разказва за борбата на българския народ за свобода от османско владичество. Книгата проследява историята на героите в едно село през времето на Априлското въстание.",
                    Pages = 280,
                    YearPublished = 1888,
                    CoverTypeId = 1,
                    ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/400x498/a4e40ebdc3e371adff845072e1c73f37/p/o/a9bb78972c12abadb60050742887fe9b/pod-igoto-30.jpg",
                },
                new Book()
                {
                    Id = 3,
                    Title = "История славянобългарска",
                    AuthorId = 3,
                    Description = "„История славянобългарска“ е творба на Паисий Хилендарски, която се смята за първата българска историографска книга. В нея се описва историята и културното развитие на българския народ.",
                    Pages = 150,
                    YearPublished = 1762,
                    CoverTypeId = 2,
                    ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/400x498/a4e40ebdc3e371adff845072e1c73f37/i/s/8357898131e0945b7bb43a6b6e15cee3/istoriya-slavyanobalgarska-uchilishtna-biblioteka---damyan-yakov-30.jpg",
                },
                new Book()
                {
                    Id = 4,
                    Title = "Железният светилник",
                    AuthorId = 4,
                    Description = "„Железният светилник“ е роман на Димитър Талев, който разказва за историята на едно българско село във времето на Освобождението. Книгата проследява събитията и промените, които преминава селото и неговите обитатели.",
                    Pages = 320,
                    YearPublished = 1937,
                    CoverTypeId = 1,
                    ImageUrl = "https://hermesbooks.bg/media/catalog/product/cache/e533a3e3438c08fe7c51cedd0cbec189/j/e/jelezniat_svetilnik_hrm_2_20200901160342.jpg"
                },
                new Book()
                {
                    Id = 5,
                    Title = "Бай Ганьо",
                    AuthorId = 5,
                    Description = "„Бай Ганьо“ е сатиричен роман на Алеко Константинов, който разказва за приключенията на българина Бай Ганьо в ранните години на 20 век. Книгата представлява портрет на типичния българин от тоя период - обаятелен, амбициозен, но и смешен поради своите недостатъци и характеристични черти на поведение.",
                    Pages = 240,
                    YearPublished = 1895,
                    CoverTypeId = 1,
                    ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/a/c5986df39a28a57f97d1598df42c7f45/bay-ganyo-pan-30.jpg",
                }
            };
        }
        private IEnumerable<GenreGenreOfBook> SeedGenresGenresOfBooks()
        {
            return new List<GenreGenreOfBook>()
            {
                new GenreGenreOfBook { BookId = 1, GenreId = 1 }, // Художествена литература
                new GenreGenreOfBook { BookId = 1, GenreId = 2 }, // Българска литература
                new GenreGenreOfBook { BookId = 2, GenreId = 1 }, // Художествена литература
                new GenreGenreOfBook { BookId = 2, GenreId = 2 }, // Българска литература
                new GenreGenreOfBook { BookId = 3, GenreId = 2 }, // Българска литература
                new GenreGenreOfBook { BookId = 3, GenreId = 3 }, // Българска класика
                new GenreGenreOfBook { BookId = 4, GenreId = 2 }, // Българска литература
                new GenreGenreOfBook { BookId = 4, GenreId = 4 }, // Световна класика
                new GenreGenreOfBook { BookId = 5, GenreId = 1 }, // Художествена литература
                new GenreGenreOfBook { BookId = 5, GenreId = 7 }, // Любовен роман
                new GenreGenreOfBook { BookId = 5, GenreId = 9 }, // Хумористична проза
            };
        }


        private IEnumerable<GenreOfMovie> SeedGenresOfMovie()
        {
            return new List<GenreOfMovie>()
            {
                new GenreOfMovie { Id = 1, Name = "Екшън" },
                new GenreOfMovie { Id = 2, Name = "Приключенски" },
                new GenreOfMovie { Id = 3, Name = "Комедия" },
                new GenreOfMovie { Id = 4, Name = "Драма" },
                new GenreOfMovie { Id = 5, Name = "Ужаси" },
                new GenreOfMovie { Id = 6, Name = "Фентъзи" },
                new GenreOfMovie { Id = 7, Name = "Научна фантастика" },
                new GenreOfMovie { Id = 8, Name = "Трилър" },
                new GenreOfMovie { Id = 9, Name = "Криминален" },
                new GenreOfMovie { Id = 10, Name = "Документален" },
                new GenreOfMovie { Id = 11, Name = "Романтичен" },
                new GenreOfMovie { Id = 12, Name = "Исторически" },
                new GenreOfMovie { Id = 13, Name = "Военен" },
                new GenreOfMovie { Id = 14, Name = "Анимация" },
                new GenreOfMovie { Id = 15, Name = "Мистерия" }
            };
        }
        private IEnumerable<Director> SeedDirectors()
        {
            return new List<Director>()
            {
                new Director { Id = 1, Name = "Джон Фавро" }, // Режисьор на "Железният човек"
                new Director { Id = 2, Name = "Джос Уидън" }, // Режисьор на "Отмъстителите"
                new Director { Id = 3, Name = "Джеймс Гън" }, // Режисьор на "Стражите на Галактиката"
                new Director { Id = 4, Name = "Райън Куглър" }, // Режисьор на "Черна пантера"
                new Director { Id = 5, Name = "Тайка Уайтити" } // Режисьор на "Тор: Рагнарок"
            };
        }



        private IEnumerable<Actor> SeedActors()
        {
            return new List<Actor>()
            {
                // За "Железният човек"
                new Actor { Id = 1, Name = "Робърт Дауни мл." },
                new Actor { Id = 2, Name = "Гуинет Полтроу" },
                new Actor { Id = 3, Name = "Джеф Бриджис" },

                // За "Отмъстителите"
                new Actor { Id = 4, Name = "Крис Евънс" },
                new Actor { Id = 5, Name = "Скарлет Йохансън" },
                new Actor { Id = 6, Name = "Марк Ръфало" },

                // За "Стражите на Галактиката"
                new Actor { Id = 7, Name = "Крис Прат" },
                new Actor { Id = 8, Name = "Зоуи Салдана" },
                new Actor { Id = 9, Name = "Дейв Батиста" },

                // За "Черна пантера"
                new Actor { Id = 10, Name = "Чедуик Боузман" },
                new Actor { Id = 11, Name = "Майкъл Б. Джордан" },
                new Actor { Id = 12, Name = "Лупита Нионго" },

                // За "Тор: Рагнарок"
                new Actor { Id = 13, Name = "Крис Хемсуърт" },
                new Actor { Id = 14, Name = "Том Хидълстън" },
                new Actor { Id = 15, Name = "Кейт Бланшет" }
            };
        }

        private IEnumerable<Movie> SeedMovies()
        {
            return new List<Movie>()
    {
                new Movie()
                {
                    Id = 1,
                    Title = "Iron Man",
                    Description = "\"Iron Man\" представя историята на Тони Старк, гений инженер и милиардер, който живее двойствен живот като супергерой. Филмът разкрива как Тони Старк, след като бива отвлечен и ранен в Афганистан, разработва високотехнологичен брониран костюм, който му позволява да се превърне в Желязният Човек. Той използва този костюм, за да се изправи срещу злодеи и престъпници, като същевременно се бори с вътрешни конфликти и дилеми. Филмът е пълен с екшън и напрежение, като зрителите са изправени пред въпроси за морал, отговорност и справедливост.",
                    URLImage = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/80C64C0B63382CD3ED2653356125F275F63D036028A77D38DC3286AD851A6833/scale?width=1200&amp;aspectRatio=1.78&amp;format=webp",
                    DirectorId = 1,
                    ReleaseDate = new DateTime(2008, 5, 2),
                    Duration = 126,
                    
                },
                new Movie()
                {
                    Id = 2,
                    Title = "The Avengers",
                    Description = "В епичния филм \"The Avengers\", Ник Фюри от S.H.I.E.L.D. събира екип от суперхора, за да формира отбора \"Мъстителите\", с цел да помогне за спасяването на Земята от Локи и неговата армия. Локи, братът на Тор и бивш бог на азгардската митология, пристига на Земята със зловещ план за завладяване на света и подчиняване на човечеството.\r\n\r\nФюри, разбирайки сериозността на заплахата, събира най-мощните супергерои от света, включително Желязният Човек (Тони Старк), Капитан Америка (Стив Роджърс), Тор, Хълк (Брус Банър), Блек Уидоу (Наташа Романоф) и Хоукай (Клинт Бартън). Заедно те формират отбора \"Мъстителите\", който трябва да се обедини и да се противопостави на Локи и неговите войски.\r\n\r\nФилмът предлага впечатляваща комбинация от екшън, вълнуващи битки, забавни диалози и емоционални моменти. \"Мъстителите\" не само представя единствено изключителния състав от супергерои, но и демонстрира тяхната способност да работят заедно, дори когато са различни по характери и мотивации.",
                    URLImage = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/B6981BDF339764E6C56626C9DE0820CEF297EAF069F62F244E0F50061219F069/scale?width=1200&aspectRatio=1.78&format=webp",
                    DirectorId = 2, 
                    ReleaseDate = new DateTime(2012, 4, 11),
                    Duration = 143,
                    
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Guardians of the Galaxy",
                    Description = "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.",
                    URLImage = "https://m.media-amazon.com/images/M/MV5BNDIzMTk4NDYtMjg5OS00ZGI0LWJhZDYtMzdmZGY1YWU5ZGNkXkEyXkFqcGdeQXVyMTI5NzUyMTIz._V1_.jpg",
                    DirectorId = 3,
                    ReleaseDate = new DateTime(2014, 7, 21),
                    Duration = 121,
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Black Panther",
                    Description = "В \"Черният пантер\" (Black Panther), наследникът на скритото кралство Уаканда, Т'Чала, трябва да изпълни своето предназначение и да въведе своя народ в ново бъдеще, докато се изправя срещу предизвикателство от миналото на своята страна.\r\n\r\nСлед смъртта на баща си, крал Т'Чака, Т'Чала се връща в Уаканда, за да поеме своята правителствена отговорност като новият крал. Той обаче е изправен пред сериозни предизвикателства, когато мистериозния войник Ерик Килмонгър, познат също като Килмонгър, се появява, за да оспори неговото място като правител.\r\n\r\nТ'Чала се изправя срещу вътрешни и външни конфликти, докато се опитва да преодолее препятствията пред Уаканда и да гарантира мира и стабилността на своя народ. Разкрива се сложна интрига, която разкрива теми за власт, наследство и самоопределяне, като Т'Чала трябва да преодолее своите собствени съмнения и грешки, за да стане истинският герой, който Уаканда се нуждае.",
                    URLImage = "https://m.media-amazon.com/images/I/91+GjGet65L._AC_UF894,1000_QL80_.jpg",
                    DirectorId = 4, 
                    ReleaseDate = new DateTime(2018, 2, 16),
                    Duration = 134,
                   
                },
                new Movie()
                {
                    Id = 5,
                    Title = "Thor: Ragnarok",
                    Description = "В \"Тор: Рагнарок\" (Thor: Ragnarok), Тор е затворен на планетата Сакаар и трябва да се състезава с времето, за да се върне в Асгард и да спре Рагнарок - разрушението на света му, на ръцете на могъщата и безмилостната злодейка Хела.\r\n\r\nСлед като е отведен отнасящата го в Сакаар, Тор се озовава в плен на тиранина Грандмастър, който го принуждава да участва в смъртоносни състезания. В този хаос той открива, че неговият стар враг, братът му Локи, също е в тези нещастия.\r\n\r\nТор и Локи се обединяват, за да победят своя общ враг - Хела, която се оказва могъща асгардианка, бягнала от затвора си, за да поеме контрол над своето родно кралство. Сблъсъкът е неизбежен, а Тор и Локи трябва да обединят силите си с нови съюзници, за да спасят Асгард от сигурната му гибел.",
                    URLImage = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p12402331_p_v10_ax.jpg",
                    DirectorId = 5,
                    ReleaseDate = new DateTime(2017, 10, 24),
                    Duration = 130,
                    
                }

           };


        }
        private IEnumerable<ActorMovie> SeedActorMovies()
        {
            return new List<ActorMovie>()
            {
                // За "Железният човек"
                new ActorMovie { ActorId = 1, MovieId = 1 },
                new ActorMovie { ActorId = 2, MovieId = 1 },
                new ActorMovie { ActorId = 3, MovieId = 1 },

                // За "Отмъстителите"
                new ActorMovie { ActorId = 4, MovieId = 2 },
                new ActorMovie { ActorId = 5, MovieId = 2 },
                new ActorMovie { ActorId = 6, MovieId = 2 },

                // За "Стражите на Галактиката"
                new ActorMovie { ActorId = 7, MovieId = 3 },
                new ActorMovie { ActorId = 8, MovieId = 3 },
                new ActorMovie { ActorId = 9, MovieId = 3 },

                // За "Черна пантера"
                new ActorMovie { ActorId = 10, MovieId = 4 },
                new ActorMovie { ActorId = 11, MovieId = 4 },
                new ActorMovie { ActorId = 12, MovieId = 4 },

                // За "Тор: Рагнарок"
                new ActorMovie { ActorId = 13, MovieId = 5 },
                new ActorMovie { ActorId = 14, MovieId = 5 },
                new ActorMovie { ActorId = 15, MovieId = 5 }
            };
        }

        private IEnumerable<GenreGenreOfMovie> SeedGenreGenresOfMovie()
        {
            return new List<GenreGenreOfMovie>()
            {
                // За "Железният човек"
                new GenreGenreOfMovie { MovieId = 1, GenreId = 1 }, // Екшън
                new GenreGenreOfMovie { MovieId = 1, GenreId = 7 }, // Научна фантастика

                // За "Отмъстителите"
                new GenreGenreOfMovie { MovieId = 2, GenreId = 1 }, // Екшън
                new GenreGenreOfMovie { MovieId = 2, GenreId = 7 }, // Научна фантастика

                // За "Стражите на Галактиката"
                new GenreGenreOfMovie { MovieId = 3, GenreId = 1 }, // Екшън
                new GenreGenreOfMovie { MovieId = 3, GenreId = 7 }, // Научна фантастика

                // За "Черна пантера"
                new GenreGenreOfMovie { MovieId = 4, GenreId = 1 }, // Екшън
                new GenreGenreOfMovie { MovieId = 4, GenreId = 6 }, // Фентъзи

                // За "Тор: Рагнарок"
                new GenreGenreOfMovie { MovieId = 5, GenreId = 1 }, // Екшън
                new GenreGenreOfMovie { MovieId = 5, GenreId = 6 }, // Фентъзи
                new GenreGenreOfMovie { MovieId = 5, GenreId = 7 }, // Научна фантастика
            };
        }
    }
}


