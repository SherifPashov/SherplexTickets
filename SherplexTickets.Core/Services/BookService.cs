using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.BookView;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.Models.Books;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repository;

        public BookService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BookAllViewModel>> AllAsync()
        {
            return await repository
                .AllReadonly<Book>()
                .Select(b => new BookAllViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author.FullName,
                    ImageUrl = b.ImageUrl,
                    Pages = b.Pages,
                    YearPublished = b.YearPublished
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CoverTypeViewModel>> AllCoverTypesAsync()
        {
            return await repository.AllReadonly<CoverType>()
                .Select(ct => new CoverTypeViewModel()
                {
                    Id = ct.Id,
                    Name = ct.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GenreViewModel>> AllGenresOfBookAsync(int bookId)
        {
            return await repository.AllReadonly<GenreGenreOfBook>()
                .Where(g=>g.BookId == bookId)
                .Select(ct => new GenreViewModel()
                {
                    Id = ct.GenreId,
                    Name = ct.Genre.Name
                })
                .ToListAsync();
        }

        public async Task<bool> BookExistsAsync(int bookId)
        {
            return await repository.AllReadonly<Book>()
                .AnyAsync(b => b.Id == bookId);
        }

        public async Task<bool> GenreExistsAsync(int genreId)
        {
            return await repository.AllReadonly<GenreOfMovie>()
                .AnyAsync(g => g.Id == genreId);
        }
        

        public async Task<bool> CoverTypeExistsAsync(int coverTypeId)
        {
            return await repository.AllReadonly<CoverType>()
                .AnyAsync(ct => ct.Id == coverTypeId);
        }

        public async Task<BookViewModel> DetailsAsync(int bookId)
        {
            Book? currentBook = await repository.AllReadonly<Book>()
                .FirstOrDefaultAsync(b => b.Id == bookId);

            var genres = await AllGenresOfBookAsync(bookId); 

            CoverType? currentCoverType = await repository.AllReadonly<CoverType>()
                .FirstOrDefaultAsync(ct => ct.Id == currentBook.CoverTypeId);

            var currentBookDetails = new BookViewModel()
            {
                Id = currentBook.Id,
                Title = currentBook.Title,
                Description = currentBook.Description,
                Pages = currentBook.Pages,
                YearPublished = currentBook.YearPublished,
                CoverType = currentCoverType.Name,
                ImageUrl = currentBook.ImageUrl,
                Genre = genres.Any()? string.Join(", ", genres.Select(g=>g.Name)):"Няма информация"
            };

            return currentBookDetails;
        }
    }
}
