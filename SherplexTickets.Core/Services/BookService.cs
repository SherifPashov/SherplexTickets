using SherplexTickets.Core.Contracts;
using SherplexTickets.Infrastructure.Data.Models.Books;
using SherplexTickets.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.ViewModels.BookView;

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

        public async Task<IEnumerable<BookAllViewModel>> SearchAsync(string input)
        {
            var searchedBooks = await repository
                .AllReadonly<Book>()
                .Where(b => input.ToLower().Contains(b.Title.ToLower())
                || input.ToLower().Contains(b.Author.ToLower())
                || input.ToLower().Contains(b.PublishingHouse.ToLower())
                || input.ToLower().Contains(b.Genre.Name.ToLower())
                || input.ToLower().Contains(b.CoverType.Name.ToLower())

                || b.Title.ToLower().Contains(input.ToLower())
                || b.Author.ToLower().Contains(input.ToLower())
                || b.PublishingHouse.ToLower().Contains(input.ToLower())
                || b.Genre.Name.ToLower().Contains(input.ToLower())
                || b.CoverType.Name.ToLower().Contains(input.ToLower()))
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

            return searchedBooks;
        }
    }
}
