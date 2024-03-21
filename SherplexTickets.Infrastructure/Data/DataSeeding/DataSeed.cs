using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;
using System.Globalization;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;

namespace SherplexTickets.Infrastructure.Data.DataSeeding
{
    internal class DataSeed
    {
        public DataSeed()
        {

            Directors = SeedDirectors();
            GenresOfMovies = SeedGenresOfMovie();
            Actors = SeedActors();
            Movies = SeedMovies();
            ActorsMovies = SeedActorMovies();
            GenresGenreOfMovies = SeedGenreGenresOfMovie();
            MovieTheaters = SeedMovieTheaters();
            MovieTheatersDailyScheduleForMovies = SeedDailySchedules();
        }


        //Movie
        public IEnumerable<Director> Directors { get; set; }
        public IEnumerable<GenreOfMovie> GenresOfMovies { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<ActorMovie> ActorsMovies { get; set; }
        public IEnumerable<GenreGenreOfMovie> GenresGenreOfMovies { get; set; }

        public IEnumerable<MovieTheater> MovieTheaters { get; set; }
        public IEnumerable<MovieTheaterDailyScheduleForMovie> MovieTheatersDailyScheduleForMovies { get; set; }





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
                    URLImage = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p170620_p_v8_az.jpg",
                    YoutubeTrailerUrl = "https://www.youtube.com/watch?v=8ugaeA-nMTc",
                    DirectorId = 1,
                    ReleaseDate = new DateTime(2008, 5, 2),
                    Duration = 126,

                },
                new Movie()
                {
                    Id = 2,
                    Title = "The Avengers",
                    Description = "В епичния филм \"The Avengers\", Ник Фюри от S.H.I.E.L.D. събира екип от суперхора, за да формира отбора \"Мъстителите\", с цел да помогне за спасяването на Земята от Локи и неговата армия. Локи, братът на Тор и бивш бог на азгардската митология, пристига на Земята със зловещ план за завладяване на света и подчиняване на човечеството.\r\n\r\nФюри, разбирайки сериозността на заплахата, събира най-мощните супергерои от света, включително Желязният Човек (Тони Старк), Капитан Америка (Стив Роджърс), Тор, Хълк (Брус Банър), Блек Уидоу (Наташа Романоф) и Хоукай (Клинт Бартън). Заедно те формират отбора \"Мъстителите\", който трябва да се обедини и да се противопостави на Локи и неговите войски.\r\n\r\nФилмът предлага впечатляваща комбинация от екшън, вълнуващи битки, забавни диалози и емоционални моменти. \"Мъстителите\" не само представя единствено изключителния състав от супергерои, но и демонстрира тяхната способност да работят заедно, дори когато са различни по характери и мотивации.",
                    URLImage = "https://fr.web.img3.acsta.net/medias/nmedia/18/85/31/58/20042068.jpg",
                    YoutubeTrailerUrl = "https://www.youtube.com/watch?v=eOrNdBpGMv8",
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
                    YoutubeTrailerUrl = "https://www.youtube.com/watch?v=d96cjJhvlMA",
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
                    YoutubeTrailerUrl = "https://www.youtube.com/watch?v=xjDjIWPwcPU",
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
                    YoutubeTrailerUrl = "https://www.youtube.com/watch?v=-mHaq88BAV4",
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

        private IEnumerable<MovieTheater> SeedMovieTheaters()
        {
            return new List<MovieTheater>()
                {
                new MovieTheater
                {
                    Id = 1,
                    Name = "Cinema City",
                    Location = "Mall Paradise Center, Хладилника, бул. „Черни връх“ 100, 1407 София",
                    Contact = "029292929",
                    OpeningTime = DateTime.ParseExact("13:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ClosingTime = DateTime.ParseExact("21:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipMdJrsk_0e4rX4NVGizrakLvwUFBD29M2GLQWNL=s680-w680-h510-rw"
                },
                new MovieTheater
                {
                    Id = 2,
                    Name = "Cinema City",
                    Location = "Mall of, ж.к. Зона Б-5, бул. „Александър Стамболийски“ 101, 1303 София",
                    Contact = "032640111",
                    OpeningTime = DateTime.ParseExact("13:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ClosingTime = DateTime.ParseExact("21:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOmXpjzG2b9aPieXQdLPx1d3wis6FwOvEmdHlSr=s680-w680-h510-rw"
                },
                new MovieTheater
                {
                    Id = 3,
                    Name = "АРЕНА THE MALL",
                    Location = "м. Къро, бул. „Цариградско шосе“ 115, 1784 София",
                    Contact = "024047121",
                    OpeningTime = DateTime.ParseExact("13:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ClosingTime = DateTime.ParseExact("21:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOO_ILS0rWgwlCk-Dz3BLpUYBGwniBoAfjs1RGN=s680-w680-h510"
                },
                new MovieTheater
                {
                    Id = 4,
                    Name = "АРЕНА МОЛ ВАРНА",
                    Location = "бул. Владислав Варненчик 186, Mall Varna Варна",
                    Contact = "024047131",
                    OpeningTime = DateTime.ParseExact("13:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ClosingTime = DateTime.ParseExact("21:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ImageUrl = "https://programata.bg/wp-content/uploads/2022/09/arena-grand-mall-varna.jpg"
                },
                new MovieTheater
                {
                    Id = 5,
                    Name = "Arena IMAX Mall Markovo Tepe Plovdiv",
                    Location = "ЦентърПловдив Център, бул. „Руски“ 54, 4000 Пловдив",
                    Contact = "024047125",
                    OpeningTime = DateTime.ParseExact("13:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ClosingTime = DateTime.ParseExact("21:00", DateTimeHouFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ImageUrl = "https://markovotepemall.bg/wp-content/uploads/2020/03/Arena.jpg"
                }
            };
        }
      
        private IEnumerable<MovieTheaterDailyScheduleForMovie> SeedDailySchedules()
        {
            var schedules = new List<MovieTheaterDailyScheduleForMovie>(){
                new MovieTheaterDailyScheduleForMovie
                {
                    Id=1,
                    MovieTheaterId = 3, // Идентификатор на киносалона "Арена"
                    MovieId = 1, // Идентификатор на филма "Kung Fu Panda"
                    Date = new DateTime(2024, 3, 23), // Дата на излъчване
                    Price = 17,
                    ShowTimes="13:30 15:00 17:00 22:30"
                },
                new MovieTheaterDailyScheduleForMovie
                {
                    Id = 2,
                    MovieTheaterId = 3, // Идентификатор на киносалона "Арена"
                    MovieId = 2, // Идентификатор на филма "Kung Fu Panda 2"
                    Date = new DateTime(2024, 3, 24), // Дата на излъчване
                    Price = 17,
                    ShowTimes="13:30 15:00 17:00 22:30"
                },
                new MovieTheaterDailyScheduleForMovie
                {
                    Id = 3,
                    MovieTheaterId = 2, // Идентификатор на киносалона "Арена"
                    MovieId = 1, // Идентификатор на филма "Kung Fu Panda"
                    Date = new DateTime(2024, 3, 25), // Дата на излъчване
                    Price = 17,
                    ShowTimes="13:30 15:00 17:00 22:30"
                },
                new MovieTheaterDailyScheduleForMovie
                {
                    Id = 4,
                    MovieTheaterId = 3, // Идентификатор на киносалона "Арена"
                    MovieId = 2, // Идентификатор на филма "Kung Fu Panda 2"
                    Date = new DateTime(2024, 3, 26), // Дата на излъчване
                    Price = 17,
                    ShowTimes="13:30 15:00 17:00 22:30"
                },
            };

            return schedules;
        }

        


    }
}


