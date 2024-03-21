

using SherplexTickets.Core.ViewModels.TheaterLinkMovie;

namespace SherplexTickets.Core.Contracts
{
    public interface IMovieTheaterMovieLink
    {
        Task<bool> MovieTheaterDailyScheduleForMovieExistsAsync(int movieTheaterDailyScheduleForMovieId);

        Task<MovieTheaterDailyScheduleForMovieEditViewModel> EditGetAsync(int dailySchedulesId);

        Task<int> EditPostAsync(MovieTheaterDailyScheduleForMovieEditViewModel movieTheaterDailyScheduleForMovieId);

        Task<MovieTheaterDailyScheduleForMovieDeleteViewModel> DeleteAsync(int movieTheaterDailyScheduleForMovieId);

        Task<int> DeleteConfirmedAsync(int movieTheaterDailyScheduleForMovieId);
    }
}
