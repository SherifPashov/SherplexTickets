using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.MovieTheater;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;

namespace SherplexTickets.Core.Services
{
    public class MovieTheaterService : IMovieTheaterService
    {
        private readonly IRepository repository;
        private readonly ITheaterManagerService theaterManagerService;

        public MovieTheaterService(
            IRepository repository,
            ITheaterManagerService theaterManagerService)
        {
            this.repository = repository;
            this.theaterManagerService = theaterManagerService;
        }

        public async Task<MovieTheaterViewModel?> GetMovieTheaterAsync(int movieTheaterId)
        {
            return await repository.AllReadonly<MovieTheater>()
                .Where(t => t.Id == movieTheaterId)
                .Select(t => new MovieTheaterViewModel()
                {
                    Id = movieTheaterId,
                    Name = t.Name,
                    Location = t.Location,
                    Contact = t.Contact,
                    OpeningTime = t.OpeningTime,
                    ClosingTime = t.ClosingTime,
                    ImageUrl = t.ImageUrl,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> MovieTheaterExistsAsync(int movieTheaterId)
        {
            return await repository.AllReadonly<MovieTheater>()
                .AnyAsync(t => t.Id == movieTheaterId);
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
                    Contact = mt.Contact,
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<MovieTheaterDailyScheduleForMovieEditViewModel>> GetWeeklyScheduleForTheaterAsync(int movieTheaterId, DateTime todayDate)
        {


            List<MovieTheaterDailyScheduleForMovieEditViewModel> dailySchedules = new List<MovieTheaterDailyScheduleForMovieEditViewModel>();

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDate = todayDate.AddDays(i);

                var schedulesForCurrentDate = await repository.AllReadonly<MovieTheaterDailyScheduleForMovie>()
                    .Where(ds =>
                            ds.MovieTheaterId == movieTheaterId &&
                            ds.Date == currentDate)
                    .Select(ds => new MovieTheaterDailyScheduleForMovieEditViewModel()
                    {
                        Id = ds.Id,
                        MovieId = ds.MovieTheaterId,
                        Price = ds.Price,
                        DayNameAndDate = ds.Date.ToString("dd.MM (dddd)"),
                        MovieTitle = ds.Movie.Title,
                        MovieImageUrl = ds.Movie.URLImage,
                        ShowTimeMovie = ds.ShowTimes.Split().ToList()

                    })
                    .ToListAsync();
                dailySchedules.AddRange(schedulesForCurrentDate);
            }

            return dailySchedules;
        }


        public async Task<MovieTheaterViewModel?> DetailsAsync(int movieTheaterId, DateTime today)
        {
            var theater = await GetMovieTheaterAsync(movieTheaterId);

            var weeklyScheduleForTheater = await GetWeeklyScheduleForTheaterAsync(movieTheaterId, today);

            theater.WeeklySchedules = weeklyScheduleForTheater;

            return theater;
        }

        public async Task<int> AddAsync(MovieTheaterAddViewModel movieTheater)
        {
            var userIdTheaterManager = await theaterManagerService
                .GetUserIdTheaterManagerByEmailAsync(movieTheater.TheaterManagerEmail);

            bool theaterManagerExists = await theaterManagerService
                .ExistsТheaterМanagerByIdAsync(userIdTheaterManager);

            if (!theaterManagerExists)
            {
                var newTheaterManager = new TheaterManager()
                {
                    UserId = userIdTheaterManager
                };

                await repository.AddAsync(newTheaterManager);
                await repository.SaveChangesAsync();
            }

            int? theaterManagerId = await theaterManagerService.GetТheaterМanagerIdAsync(userIdTheaterManager);

            var theater = new MovieTheater()
            {
                Name = movieTheater.Name,
                ImageUrl = movieTheater.ImageUrl,
                Contact = movieTheater.Contact,
                Location = movieTheater.Location,
                OpeningTime = movieTheater.OpeningTime,
                ClosingTime = movieTheater.ClosingTime,
                TheaterManagerId = theaterManagerId.Value  
            };

            await repository.AddAsync(theater);
            await repository.SaveChangesAsync();

            return theater.Id;
        }

        public async Task<MovieTheaterEditViewModel> EditGetAsync(int movieTheaterId)
        {
            var currentMovieTheater = await repository.All<MovieTheater>()
                .FirstOrDefaultAsync(mt => mt.Id == movieTheaterId);

            return new MovieTheaterEditViewModel()
            {
                Name = currentMovieTheater.Name,
                ImageUrl = currentMovieTheater.ImageUrl,
                Contact = currentMovieTheater.Contact,
                Location = currentMovieTheater.Location,
                OpeningTime = currentMovieTheater.OpeningTime,
                ClosingTime = currentMovieTheater.ClosingTime,

            };
        }

        public async Task<int> EditPostAsync(MovieTheaterEditViewModel movieTheaterForm)
        {
            var movieTheater = await repository.All<MovieTheater>()
                .FirstOrDefaultAsync(mt => mt.Id == movieTheaterForm.Id);

            movieTheater.Name = movieTheaterForm.Name;
            movieTheater.ImageUrl = movieTheaterForm.ImageUrl;
            movieTheater.Contact = movieTheaterForm.Contact;
            movieTheater.Location = movieTheaterForm.Location;
            movieTheater.OpeningTime = movieTheaterForm.OpeningTime;
            movieTheater.ClosingTime = movieTheaterForm.ClosingTime;


            await repository.SaveChangesAsync();

            return movieTheater.Id;
        }

        public async Task<MovieTheaterDeleteViewModel> DeleteAsync(int movieTheaterId)
        {
            var movieTheater = await repository
                .AllReadonly<MovieTheater>().Where(b => b.Id == movieTheaterId)
                .FirstOrDefaultAsync();

            var deleteForm = new MovieTheaterDeleteViewModel()
            {
                Id = movieTheater.Id,
                Name = movieTheater.Name,
                ImageUrl = movieTheater.ImageUrl,
                ClosingTime = movieTheater.ClosingTime,
                OpeningTime = movieTheater.OpeningTime,
                Contact = movieTheater.Contact,
                Location = movieTheater.Location,
            };

            return deleteForm;
        }

        public async Task DeleteConfirmedAsync(int movieTheaterId)
        {
            var movieTheater = await repository.All<MovieTheater>()
                .Where(b => b.Id == movieTheaterId)
                .FirstOrDefaultAsync();


            var dailyMovieLink = await repository.All<MovieTheaterDailyScheduleForMovie>()
                .Where(mtdm => mtdm.MovieId == movieTheater.Id)
                .ToListAsync();
            if (movieTheater != null)
            {
                if (dailyMovieLink != null && dailyMovieLink.Any())
                {
                    repository.DeleteRange(dailyMovieLink);
                }
                await repository.SaveChangesAsync();

                repository.Delete(movieTheater);
                await repository.SaveChangesAsync();
            }

        }

    }
}
