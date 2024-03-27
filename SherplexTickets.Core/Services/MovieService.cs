using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.Enums;
using SherplexTickets.Core.ViewModels.Movies;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Core.ViewModels.QueryModels;
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

        public async Task<Movie?> FindMovieIdAsync(int movieId)
        {
            return await repository.AllReadonly<Movie>()
                .FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public async Task<MovieReview?> FindMovieReviewAsync(int reviewId)
        {
            return await repository.AllReadonly<MovieReview>()
                .FirstOrDefaultAsync(mr => mr.Id == reviewId);
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
            return await repository.AllReadonly<GenreMovie>()
                .Where(g => g.MovieId == movieId)
                .Select(g => new GenreViewModel()
                {
                    Id = g.GenreId,
                    Name = g.Genre.Name
                })
                .ToListAsync();
        }
        public static string GetEmbeddedYouTubeUrl(string originalUrl)
        {
            if (originalUrl.Contains("youtube.com"))
            {
                var videoId = originalUrl.Split(new[] { "?v=" }, StringSplitOptions.RemoveEmptyEntries)[1];

                return $"https://www.youtube.com/embed/{videoId}";
            }

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

        public async Task<MovieQueryServiceModel> AllAsync(
            string? searchTerm = null,
            MovieSorting? sorting = MovieSorting.TitleAscending,
            string? genre = null,
            int currentPage = 1,
            int moviesPerPage = 8)
        {

            var allMoviesShow = repository.AllReadonly<Movie>();

            if (genre != null)
            {
                allMoviesShow = allMoviesShow
                    .Where(m => m.Genres.Any(g => g.Genre.Name.ToLower() == genre.ToLower()));
            }
            if (searchTerm != null)
            {
                var lowercaseInput = searchTerm.ToLower();

                allMoviesShow = allMoviesShow
                    .Where(m =>
                        m.Title.ToLower().Contains(lowercaseInput)
                        || m.Description.ToLower().Contains(lowercaseInput)
                        || m.Genres.Any(ggb => ggb.Genre.Name.ToLower().Contains(lowercaseInput))
                        || m.Director.Name.ToLower().Contains(lowercaseInput));

            }

            allMoviesShow = sorting switch
            {
                MovieSorting.TitleAscending => allMoviesShow.OrderBy(m => m.Title),
                MovieSorting.TitleDescending => allMoviesShow.OrderByDescending(m => m.Title),
                MovieSorting.ReleaseDateAscending => allMoviesShow.OrderBy(m => m.ReleaseDate.Year),
                MovieSorting.ReleaseDateDescending => allMoviesShow.OrderByDescending(m => m.ReleaseDate.Year),
                _ => allMoviesShow.OrderByDescending(b => b.Id),
            };

            int totalMovies = await allMoviesShow.CountAsync();

            var movies = await allMoviesShow
                .Skip((currentPage - 1) * moviesPerPage)
                .Take(moviesPerPage)
                .ProjectToMovieAllViewModel()
                .ToListAsync();

            return new MovieQueryServiceModel()
            {
                Movies = movies,
                TotalMoviesCount = totalMovies,
            };
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
                var genre = await repository.AllReadonly<Genre>().FirstOrDefaultAsync(g => g.Id == genreId);
                if (genre != null)
                {
                    movie.Genres.Add(new GenreMovie()
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
                ActorsName = string.Join(", ", actors.Select(a => a.FullName)),
                SelectGenreIds = genres.Select(a => a.Id),
            };

            movieForm.Genres = await AllGenresAsync();

            return movieForm;
        }

        public async Task<int> EditPostAsync(MovieEditViewModel movieForm)
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

            var allGenreMovie = await repository.All<GenreMovie>()
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

                repository.DeleteRange<GenreMovie>(allGenreMovie);
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
                var genre = await repository.AllReadonly<Genre>().FirstOrDefaultAsync(g => g.Id == genreId);
                if (genre != null)
                {
                    movie.Genres.Add(new GenreMovie()
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
                Duration = movie.Duration.ToString(),
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

            var genresMovie = await repository.All<GenreMovie>()
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

        public async Task<IEnumerable<MovieIndexViewModel>> GetTop10NewestPopularMovies()
        {
            return await repository.AllReadonly<Movie>()
                .OrderByDescending(m => m.ReleaseDate)
                .Select(m => new MovieIndexViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    URLImage = m.URLImage,
                    YoutubeTrailerUrl = GetEmbeddedYouTubeUrl(m.YoutubeTrailerUrl)
                })
                .Take(10)
                .ToListAsync();
        }

        public async Task<int> AddMovieReviewAsync(MovieReviewAddViewModel movieReviewForm)
        {
            var movieReview = new MovieReview
            {
                UserId = movieReviewForm.UserId,
                MovieId = movieReviewForm.MovieId,
                Title = movieReviewForm.Title,
                Description = movieReviewForm.Description,
                Rate = movieReviewForm.Rate,

            };

            await repository.AddAsync<MovieReview>(movieReview);
            await repository.SaveChangesAsync();

            return movieReview.Id;
        }

        public async Task<MovieReviewQueryServiceModel> AllMovieReviewsAsync(
            int movieId,
            string movieTitle,
            MovieReviewSorting sorting = MovieReviewSorting.Newest,
            int currentPage = 1,
            int reviewsPerPage = 4)
        {
            var allReviewsToShow = repository.AllReadonly<MovieReview>()
                .Where(mr => mr.MovieId == movieId);

            allReviewsToShow = sorting switch
            {
                MovieReviewSorting.Oldest => allReviewsToShow.OrderBy(mr => mr.Id),
                MovieReviewSorting.RateAscending => allReviewsToShow.OrderBy(mr => mr.Rate),
                MovieReviewSorting.RateDescending => allReviewsToShow.OrderByDescending(mr => mr.Rate),
                _ => allReviewsToShow.OrderByDescending(mr => mr.Id),

            };

            var reviews = await allReviewsToShow
                .Skip((currentPage - 1) * reviewsPerPage)
                .Take(reviewsPerPage)
                .Select(mr => new MovieReviewServiceModel()
                {
                    Id = mr.Id,
                    Title = mr.Title,
                    Description = mr.Description,
                    Rate = mr.Rate,
                    MovieId = mr.MovieId,
                    UserId = mr.UserId,
                })
                .ToListAsync();
            int totalReviews = reviews.Count;
            return new MovieReviewQueryServiceModel()
            {
                MovieReviews = reviews,
                TotalReviewsCount = totalReviews
            };
        }

        public async Task<MovieReviewEditViewModel> EditMovieReviewGetAsync(int reviewId)
        {
            var cuurMovieReview = await repository.GetByIdAsync<MovieReview>(reviewId);

            var movieReviewEditForm = new MovieReviewEditViewModel()
            {
                Id = reviewId,
                Title = cuurMovieReview.Title,
                Description = cuurMovieReview.Description,
                Rate = cuurMovieReview.Rate,
                MovieId = cuurMovieReview.MovieId,
                UserId = cuurMovieReview.UserId,
            };
            return movieReviewEditForm;
        }

        public async Task<int> EditMovieReviewPostAsync(MovieReviewEditViewModel movieReveiwForm)
        {
            var currMovieReview = await repository.GetByIdAsync<MovieReview>(movieReveiwForm.Id);

            currMovieReview.Title = movieReveiwForm.Title;
            currMovieReview.Rate = movieReveiwForm.Rate;
            currMovieReview.Description = movieReveiwForm.Description;

            await repository.SaveChangesAsync();
            return currMovieReview.MovieId;
        }

        public async Task<MovieReviewDeleteViewModel> DeleteMovieReviewAsync(int reveiwId)
        {
            var review = await repository.GetByIdAsync<MovieReview>(reveiwId);
            var movie = await repository.GetByIdAsync<Movie>(review.MovieId);

            return new MovieReviewDeleteViewModel()
            {
                MovieId = movie.Id,
                ReviewId = review.Id,
            };
        }
        public async Task<int> DeleteMovieReviewConfirmedAsync(int reviewId)
        {
            var review = await repository.GetByIdAsync<MovieReview>(reviewId);

            await repository.DeleteAsync<MovieReview>(review);
            await repository.SaveChangesAsync();

            return review.MovieId;
        }
    }
}
