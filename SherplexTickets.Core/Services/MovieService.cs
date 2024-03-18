using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.BookView;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.DataConstants;
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
                    Duration = b.Duration.ToString(),
                    YearPublished = b.ReleaseDate.Year.ToString(),

                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GenreViewModel>> AllGenresAsync()
        {
            return await repository.AllReadonly<GenreOfMovie>()
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
                .Where(am => am.MovieId == movieId)
                .Select(ct => new ActorViewModel()
                {
                    Id = ct.ActorId,
                    FullName = ct.Actor.Name,
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<GenreViewModel>> AllGenreAsync(int movieId)
        {
            return await repository.AllReadonly<GenreGenreOfMovie>()
                .Where(g => g.MovieId == movieId)
                .Select(g => new GenreViewModel()
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
            var currentDirector = await repository.AllReadonly<Director>()
                .FirstOrDefaultAsync(d => d.Id == currentMovie.DirectorId);

            var genres = await AllGenreAsync(movieId);

            var actors = await AllActorsAsync(movieId);


            var currentMovieDetails = new MovieViewModel()
            {
                Id = currentMovie.Id,
                Title = currentMovie.Title,
                Description = currentMovie.Description,
                URLImage = currentMovie.URLImage,
                YearPublished = currentMovie.ReleaseDate.ToString(DataConstants.DateTimeDefaultFormat),
                Duration = currentMovie.Duration.ToString(),
                DirectorName = currentDirector.Name,
                ActorsName = actors.Any() ? string.Join(", ", actors.Select(a => a.FullName)) : "Няма информация",
                GenresName = genres.Any() ? string.Join(", ", genres.Select(g => g.Name)) : "Няма информация",
            };

            return currentMovieDetails;
        }

        public async Task<IEnumerable<MovieAllViewModel>> SearchAsync(string input)
        {
            var lowercaseInput = input.ToLower();

            var searchedMovies = await repository.AllReadonly<Movie>()
                .Where(m =>
                    m.Title.ToLower().Contains(lowercaseInput)
                    || m.Description.ToLower().Contains(lowercaseInput)
                    || m.Genres.Any(ggb => ggb.Genre.Name.ToLower().Contains(lowercaseInput))
                    || m.Director.Name.ToLower().Contains(lowercaseInput))
                .Select(b => new MovieAllViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    URLImage = b.URLImage,
                    Duration = b.Duration.ToString(),
                    YearPublished = b.ReleaseDate.Year.ToString(DataConstants.DateTimeDefaultFormat),
                })
                .ToListAsync();

            return searchedMovies;
        }
        public async Task<int> AddAsync(MovieAddViewModel movieForm)
        {
            Director? director = await repository.AllReadonly<Director>()
                .FirstOrDefaultAsync(d => d.Name.ToLower() == movieForm.Director.ToLower());

            if (director == null)
            {
                director = new Director { Name = movieForm.Director };
                await repository.AddAsync(director);
            }

            Movie movie = new Movie
            {
                Title = movieForm.Title,
                Description = movieForm.Description,
                ReleaseDate = movieForm.ReleaseDate,
                URLImage = movieForm.URLImage,
                Duration = movieForm.Duration,
                Director = director, 
            };

            await repository.AddAsync(movie);

            await repository.SaveChangesAsync();

            foreach (var genreId in movieForm.GenreIds)
            {
                var genre = await repository.AllReadonly<GenreOfMovie>().FirstOrDefaultAsync(g => g.Id == genreId);
                if (genre != null)
                {
                    movie.Genres.Add(new GenreGenreOfMovie()
                    {
                        Genre = genre,
                        Movie = movie,
                    });
                }
            }
            foreach (var actorName in movieForm.ActorsName.Split(new string[] { ",", ", " }, StringSplitOptions.RemoveEmptyEntries))
            {
                var actor = await repository.AllReadonly<Actor>().FirstOrDefaultAsync(a => a.Name.ToLower() == actorName.ToLower());

                if (actor == null)
                {
                    actor = new Actor { Name = actorName };
                    await repository.AddAsync(actor);

                }

                movie.ActorsMovies.Add(new ActorMovie { Actor = actor, Movie = movie });
            }

            await repository.SaveChangesAsync();

            return movie.Id;
        }



    }
}
