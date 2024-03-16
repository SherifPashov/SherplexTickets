using SherplexTickets.Core.Contracts;
using SherplexTickets.Infrastructure.Data.Models.Books;
using SherplexTickets.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.ViewModels.BookView;
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
                    Author = b.Author,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    Pages = b.Pages,
                    PublishingHouse = b.PublishingHouse,
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

        public async Task<IEnumerable<GenreViewModel>> AllGenresAsync()
        {
            return await repository.AllReadonly<Genre>()
                .Select(ct => new GenreViewModel()
                {
                    Id = ct.Id,
                    Name = ct.Name
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
            return await repository.AllReadonly<Genre>()
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


            Genre? currentGenre = await repository.AllReadonly<Genre>()
                .FirstOrDefaultAsync(g => g.Id == currentBook.GenreId);

            CoverType? currentCoverType = await repository.AllReadonly<CoverType>()
                .FirstOrDefaultAsync(ct => ct.Id == currentBook.CoverTypeId);

            var currentBookDetails = new BookViewModel()
            {
                Id = currentBook.Id,
                Title = currentBook.Title,
                Author = currentBook.Author,
                Genre = currentGenre.Name,
                Description = currentBook.Description,
                Pages = currentBook.Pages,
                PublishingHouse = currentBook.PublishingHouse,
                YearPublished = currentBook.YearPublished,
                CoverType = currentCoverType.Name,
                Price = currentBook.Price,
                ImageUrl = currentBook.ImageUrl
            };

            return currentBookDetails;
        }
    }
}
