using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.TheaterLinkMovie;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;

namespace SherplexTickets.Core.Services
{
    public class MovieTheaterMovieLinkService : IMovieTheaterMovieLink
    {
        private readonly IRepository repository;

        public MovieTheaterMovieLinkService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> MovieTheaterDailyScheduleForMovieExistsAsync(int movieTheaterDailyScheduleForMovieId)
        {
            return await repository.AllReadonly<MovieTheaterDailyScheduleForMovie>()
                .AnyAsync(mtdfm => mtdfm.Id == movieTheaterDailyScheduleForMovieId);
        }
        public async Task<IEnumerable<DailyMovieViewModel>> GetAllMovie()
        {
            return await repository.AllReadonly<Movie>()
                .Select(m => new DailyMovieViewModel()
                {
                    MovieId = m.Id,
                    Title = m.Title
                })
                .ToListAsync();
        }
        public async Task<bool> MovieTheaterDailyScheduleForMovieAddDateExistsAsync(int movieTheaterId, int movieId, DateTime date)
        {
            return await repository.AllReadonly<MovieTheaterDailyScheduleForMovie>()
                .AnyAsync(mtdfm => mtdfm.MovieId == movieId &&
                                    mtdfm.MovieTheaterId == movieTheaterId &&
                                    mtdfm.Date == date);
        }
        public async Task<MovieTheaterDailyScheduleForMovieEditViewModel> EditGetAsync(int movieTheaterDailyScheduleForMovieId)
        {
            var currentMovieTheaterDailyScheduleForMovie = await repository.All<MovieTheaterDailyScheduleForMovie>()
                .FirstOrDefaultAsync(b => b.Id == movieTheaterDailyScheduleForMovieId);

            var movie = await repository.All<Movie>()
                .FirstOrDefaultAsync(m => m.Id == currentMovieTheaterDailyScheduleForMovie.MovieId);


            var movieTheaterLinkMovieForm = new ViewModels.TheaterLinkMovie.MovieTheaterDailyScheduleForMovieEditViewModel()
            {
                Id = currentMovieTheaterDailyScheduleForMovie.Id,
                MovieImageUrl = movie.URLImage,
                MovieTitle = movie.Title,
                Price = currentMovieTheaterDailyScheduleForMovie.Price.ToString(),
                ShowTimeMovie = currentMovieTheaterDailyScheduleForMovie.ShowTimes,
                Date = currentMovieTheaterDailyScheduleForMovie.Date,

            };

            return movieTheaterLinkMovieForm;
        }

        public async Task<int> EditPostAsync(MovieTheaterDailyScheduleForMovieEditViewModel movieTheaterDailyScheduleForMovieId)
        {
            var currentMovieTheaterDailyScheduleForMovie = await repository.All<MovieTheaterDailyScheduleForMovie>()
                .FirstOrDefaultAsync(b => b.Id == movieTheaterDailyScheduleForMovieId.Id);

            decimal.TryParse(movieTheaterDailyScheduleForMovieId.Price, out decimal parsedPrice);

            currentMovieTheaterDailyScheduleForMovie.Price = parsedPrice;
            currentMovieTheaterDailyScheduleForMovie.ShowTimes = movieTheaterDailyScheduleForMovieId.ShowTimeMovie.ToString();
            currentMovieTheaterDailyScheduleForMovie.Date = movieTheaterDailyScheduleForMovieId.Date;

            await repository.SaveChangesAsync();

            return currentMovieTheaterDailyScheduleForMovie.MovieTheaterId;
        }

        public async Task<MovieTheaterDailyScheduleForMovieDeleteViewModel> DeleteAsync(int movieTheaterDailyScheduleForMovieId)
        {
            var currentMovieTheaterDailyScheduleForMovie = await repository
                .AllReadonly<MovieTheaterDailyScheduleForMovie>().Where(b => b.Id == movieTheaterDailyScheduleForMovieId)
                .FirstOrDefaultAsync();

            var movie = await repository.All<Movie>()
               .FirstOrDefaultAsync(m => m.Id == currentMovieTheaterDailyScheduleForMovie.MovieId);

            var deleteForm = new MovieTheaterDailyScheduleForMovieDeleteViewModel()
            {
                Id = currentMovieTheaterDailyScheduleForMovie.Id,
                MovieImageUrl = movie.URLImage,
                MovieTitle = movie.Title,
                Price = currentMovieTheaterDailyScheduleForMovie.Price,
                ShowTimeMovie = currentMovieTheaterDailyScheduleForMovie.ShowTimes.Split().ToList(),
                Date = currentMovieTheaterDailyScheduleForMovie.Date,
            };

            return deleteForm;
        }

        public async Task<int> DeleteConfirmedAsync(int movieTheaterDailyScheduleForMovieId)
        {
            var currentMovieTheaterDailyScheduleForMovie = await repository
                .AllReadonly<MovieTheaterDailyScheduleForMovie>().Where(b => b.Id == movieTheaterDailyScheduleForMovieId)
                .FirstOrDefaultAsync();

            repository.Delete(currentMovieTheaterDailyScheduleForMovie);
            await repository.SaveChangesAsync();

            return currentMovieTheaterDailyScheduleForMovie.MovieTheaterId;
        }

        public async Task<bool> MovieExistsAsync(int movieId)
        {
            return await repository.AllReadonly<Movie>()
                .AnyAsync(m => m.Id == movieId);
        }

        public async Task<int> AddAsync(MovieTheaterMovieLinkAddViewModel dailyForm)
        {
            MovieTheaterDailyScheduleForMovie movieTheaterDailyScheduleForMovie = new()
            {
                MovieId = dailyForm.MovieId,
                MovieTheaterId = dailyForm.MovieTheaterId,
                Price = dailyForm.Price,
                Date = dailyForm.Date,
                ShowTimes = dailyForm.ShowTimes,
            };
            await repository.AddAsync(movieTheaterDailyScheduleForMovie);
            await repository.SaveChangesAsync();

            return movieTheaterDailyScheduleForMovie.Id;
        }
    }
}
