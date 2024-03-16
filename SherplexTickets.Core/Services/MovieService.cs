using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository repository;

        public MovieService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<MovieAllViewModel>> AllAsync()
        {
            return await repository
                .AllReadonly<Movie>()
                .Select(b => new MovieAllViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    URLImage = b.URLImage,
                    MovieWhatchTime = b.MovieWhatchTime,
                    YearPublished = b.YearPublished
                    
                })
                .ToListAsync();
        }
    }
}
