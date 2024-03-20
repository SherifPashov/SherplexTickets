using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.MovieTheater;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;
namespace SherplexTickets.Core.Services
{
    public class MovieTheaterService : IMovieTheaterService
    {
        private readonly IRepository repository;

        public MovieTheaterService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<MovieTheaterViewModel?> GetMovieTheater(int theaterId)
        {
            return await repository.AllReadonly<MovieTheater>()
                .Where(t => t.Id == theaterId)
                .Select(t=> new MovieTheaterViewModel()
                {
                    Id = theaterId,
                    Name = t.Name,
                    Location = t.Location,
                    Contact = t.Contact,
                    OpeningTime = t.OpeningTime,
                    ClosingTime = t.ClosingTime,
                    ImageUrl = t.ImageUrl,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> MovieTheaterExistsAsync(int theaterId)
        {
            return await repository.AllReadonly<MovieTheater>()
                .AnyAsync(t=> t.Id == theaterId);
        }

        public async Task<IEnumerable<MovieTheaterAllViewModel>> AllAsync()
        {
            return await repository.All<MovieTheater>()
                .Select(mt => new MovieTheaterAllViewModel()
                {
                    Id = mt.Id,
                    Name = mt.Name,
                    Location = mt.Location,
                    OpeningTime = mt.OpeningTime,
                    ClosingTime = mt.ClosingTime,
                    ImageUrl = mt.ImageUrl,
                    Contact=mt.Contact,
                })
                .ToListAsync();
        }

        public async  Task<MovieTheaterViewModel?> DetailsAsync(int bookId)
        {
            var theater = await GetMovieTheater(bookId);

            return theater;
        }

        
    }
}
