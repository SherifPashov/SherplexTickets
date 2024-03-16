using SherplexTickets.Infrastructure.Data.Models.Books;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data.DataSeeding
{
    internal class DataSeed
    {
        public DataSeed()
        {
            GenresOfMovies= SeedGenresOfMovie();
            GenresOfBooks= SeedGenresOfBook();
            CoverTypes = SeedCoverTypes();
            Authors = SeedAuthor();
            Books = SeedBooks();
            GenresGenresOfBooks = SeedGenresGenresOfBooks();
        }
        public IEnumerable<GenreOfMovie> GenresOfMovies { get; set; }
        public IEnumerable<GenreOfBook> GenresOfBooks { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<CoverType> CoverTypes { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<GenreGenreOfBook> GenresGenresOfBooks { get; set; }

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
    }
}
