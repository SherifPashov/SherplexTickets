using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.BookView;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
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
                    MovieWhatchTime = b.MovieWhatchTime.ToString(),
                    YearPublished = b.YearPublished.Year.ToString(),
                    
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

        public async Task<bool> MovieExistsAsync(int movieId)
        {
            return await repository.AllReadonly<Movie>()
                .AnyAsync(m => m.Id == movieId);
        }

        public async Task<IEnumerable<ActorViewModel>> AllActorsAsync(int movieId)
        {
            return await repository.AllReadonly<ActorMovie>()
                .Where(am=>am.MovieId == movieId)
                .Select(ct => new ActorViewModel()
                {
                    Id = ct.ActorId,
                    FullName = ct.Actor.FullName,
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<GenreViewModel>> AllGenreAsync(int movieId)
        {
            return await repository.AllReadonly<GenreMovie>()
                .Where(g=>g.MovieId == movieId)
                .Select(g=>new GenreViewModel()
                {
                    Id = g.GenreId,
                    Name = g.Genre.Name
                })
                .ToListAsync();
        }
        public async Task<MovieViewModel> DetailsAsync(int movieId)
        {
            Movie? currentMovie = await repository.AllReadonly<Movie>()
                .FirstOrDefaultAsync(m => m.Id == movieId);


            var genres = await AllGenreAsync (movieId);

            var actors = await AllActorsAsync (movieId);


            var currentMovieDetails = new MovieViewModel()
            {
                Id = currentMovie.Id,
                Title = currentMovie.Title,
                Description = currentMovie.Description,
                URLImage = currentMovie.URLImage,
                YearPublished = currentMovie.YearPublished.Year.ToString(),
                MovieWhatchTime = currentMovie.MovieWhatchTime.ToString(),
                DirectorName = currentMovie.Director.FullName,
                ActorsName = actors.Any() ? string.Join(", ", actors) : "Няма информация",
                GenresName = genres.Any() ? string.Join(", ", genres) : "Няма информация",
        };

            return currentMovieDetails;
        }

    }
}
