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
                Price = currentMovieTheaterDailyScheduleForMovie.Price,
                ShowTimeMovie = currentMovieTheaterDailyScheduleForMovie.ShowTimes,
                Date = currentMovieTheaterDailyScheduleForMovie.Date,

            };

            return movieTheaterLinkMovieForm;
        }

        public async Task<int> EditPostAsync(MovieTheaterDailyScheduleForMovieEditViewModel movieTheaterDailyScheduleForMovieId)
        {
            var currentMovieTheaterDailyScheduleForMovie = await repository.All<MovieTheaterDailyScheduleForMovie>()
                .FirstOrDefaultAsync(b => b.Id == movieTheaterDailyScheduleForMovieId.Id);


            currentMovieTheaterDailyScheduleForMovie.Price = movieTheaterDailyScheduleForMovieId.Price;
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
    }
}
