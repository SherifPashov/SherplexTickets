using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.BookView;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.DataConstants;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using System.IO;

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
                    YoutubeTrailerUrl = b.YoutubeTrailerUrl,
                    Duration = b.Duration.ToString(),
                    ReleaseDate = b.ReleaseDate.Year.ToString(),

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


        public async Task<IEnumerable<GenreViewModel>> AllGenresAsync(int movieId)
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
        public string GetEmbeddedYouTubeUrl(string originalUrl)
        {
            // Проверка дали подаденият URL е от YouTube
            if (originalUrl.Contains("youtube.com"))
            {
                // Извличане на уникалния идентификатор на видеото от URL адреса
                var videoId = originalUrl.Split(new[] { "?v=" }, StringSplitOptions.RemoveEmptyEntries)[1];

                // Създаване на URL адрес за вграждане с уникалния идентификатор на видеото
                return $"https://www.youtube.com/embed/{videoId}";
            }

            // Ако URL адресът не е от YouTube, връщаме го както е
            return originalUrl;
        }

        public async Task<MovieViewModel> DetailsAsync(int movieId)
        {
            Movie? currentMovie = await repository.AllReadonly<Movie>()
                .FirstOrDefaultAsync(m => m.Id == movieId);
            var currentDirector = await repository.AllReadonly<Director>()
                .FirstOrDefaultAsync(d => d.Id == currentMovie.DirectorId);

            var genres = await AllGenresAsync(movieId);

            var actors = await AllActorsAsync(movieId);


            var currentMovieDetails = new MovieViewModel()
            {
                Id = currentMovie.Id,
                Title = currentMovie.Title,
                Description = currentMovie.Description,
                URLImage = currentMovie.URLImage,
                YoutubeTrailerUrl = GetEmbeddedYouTubeUrl(currentMovie.YoutubeTrailerUrl),
                ReleaseDate = currentMovie.ReleaseDate.ToString(DataConstants.DateTimeDefaultFormat),
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
                    YoutubeTrailerUrl = b.YoutubeTrailerUrl,
                    Duration = b.Duration.ToString(),
                    ReleaseDate = b.ReleaseDate.Year.ToString(DataConstants.DateTimeDefaultFormat),
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
                YoutubeTrailerUrl = movieForm.YoutubeTrailerUrl,
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
            foreach (var actorName in movieForm.ActorsName.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries))
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

        public async Task<MovieEditViewModel> EditGetAsync(int movieId)
        {
            var currentMovie = await repository.All<Movie>()
                .FirstOrDefaultAsync(b => b.Id == movieId);

            var director = await repository.All<Director>()
                .FirstOrDefaultAsync(d => d.Id == currentMovie.DirectorId);

            var actors = await AllActorsAsync(movieId);
            var genres = await AllGenresAsync(movieId);

            var movieForm = new MovieEditViewModel()
            {
                Id = movieId,
                Title = currentMovie.Title,
                Description = currentMovie.Description,
                ReleaseDate = currentMovie.ReleaseDate,
                URLImage = currentMovie.URLImage,
                YoutubeTrailerUrl = currentMovie.YoutubeTrailerUrl,
                Duration = currentMovie.Duration,
                Director = director.Name,
                ActorsName = string.Join(", ", actors.Select(a=>a.FullName)),
                SelectGenreIds = genres.Select(a=>a.Id),
            };

            movieForm.Genres = await AllGenresAsync();

            return movieForm;
        }

        public async Task<int> EditPostAsync(MovieEditViewModel movieForm )
        {


            Director? director = await repository.AllReadonly<Director>()
               .FirstOrDefaultAsync(d => d.Name.ToLower() == movieForm.Director.ToLower());

            if (director == null)
            {
                director = new Director { Name = movieForm.Director };
                await repository.AddAsync(director);
            }

            var movie = await repository.All<Movie>()
               .Where(b => b.Id == movieForm.Id)
               .FirstOrDefaultAsync();

            var allGenreMovie = await repository.All<GenreGenreOfMovie>()
                .Where(gm => gm.MovieId == movie.Id)
                .ToListAsync();
            var allActorMovie = await repository.All<ActorMovie>()
                .Where(am => am.MovieId == movie.Id)
                .ToListAsync();

            if (allActorMovie != null)
            {
                repository.DeleteRange<ActorMovie>(allActorMovie);  

            }
            if (allGenreMovie != null)
            {

                repository.DeleteRange<GenreGenreOfMovie>(allGenreMovie);
            }
            await repository.SaveChangesAsync();



            movie.Title = movieForm.Title;
            movie.Description = movieForm.Description;
            movie.ReleaseDate = movieForm.ReleaseDate;
            movie.URLImage = movieForm.URLImage;
            movie.YoutubeTrailerUrl = movieForm.YoutubeTrailerUrl;
            movie.Duration = movieForm.Duration;
            movie.Director = director;

            

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

            foreach (var actorName in movieForm.ActorsName.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries))
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
        public async Task<MovieDeleteViewModel> DeleteAsync(int movieId)
        {
            var movie = await repository
                .AllReadonly<Movie>().Where(b => b.Id == movieId)
                .FirstOrDefaultAsync();

            var deleteForm = new MovieDeleteViewModel()
            {
                Id = movie.Id,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy"),
                URLImage = movie.URLImage,
                Duration=movie.Duration.ToString(),
                Title = movie.Title,
            };

            return deleteForm;
        }

        public async Task DeleteConfirmedAsync(int bookId)
        {
            var movie = await repository.All<Movie>()
                .Where(b => b.Id == bookId)
                .FirstOrDefaultAsync();

            var actorsMovie = await repository.All<ActorMovie>()
                .Where(am => am.MovieId == movie.Id)
                .ToListAsync();

            var genresMovie = await repository.All<GenreGenreOfMovie>()
                .Where(gm => gm.MovieId == movie.Id)
                .ToListAsync();

            var daily = await repository.All<MovieTheaterDailyScheduleForMovie>()
                .Where(mtdm => mtdm.MovieId == movie.Id)
                .ToListAsync();
            if (movie != null)
            {
                if (genresMovie != null && genresMovie.Any())
                {
                    repository.DeleteRange(genresMovie);
                }

                if (actorsMovie != null && actorsMovie.Any())
                {
                    repository.DeleteRange(actorsMovie);
                }

                if (daily != null && daily.Any())
                {
                    repository.DeleteRange(daily);
                }
                await repository.SaveChangesAsync();

                repository.Delete(movie);
                await repository.SaveChangesAsync();
            }

        }
    }
}
