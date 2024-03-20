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
    }
}
