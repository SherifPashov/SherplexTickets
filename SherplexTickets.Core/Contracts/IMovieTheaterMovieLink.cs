

using SherplexTickets.Core.ViewModels.TheaterLinkMovie;

namespace SherplexTickets.Core.Contracts
{
    public interface IMovieTheaterMovieLink
    {
        Task<IEnumerable<DailyMovieViewModel>> GetAllMovie();

        Task<int> AddAsync(MovieTheaterMovieLinkAddViewModel dailyForm);

        Task<bool> MovieTheaterDailyScheduleForMovieExistsAsync(int movieTheaterDailyScheduleForMovieId);

        Task<bool> MovieTheaterDailyScheduleForMovieAddDateExistsAsync(int movieTheaterId, int movieId, DateTime date);

        Task<MovieTheaterDailyScheduleForMovieEditViewModel> EditGetAsync(int dailySchedulesId);

        Task<int> EditPostAsync(MovieTheaterDailyScheduleForMovieEditViewModel movieTheaterDailyScheduleForMovieId);

        Task<MovieTheaterDailyScheduleForMovieDeleteViewModel> DeleteAsync(int movieTheaterDailyScheduleForMovieId);

        Task<int> DeleteConfirmedAsync(int movieTheaterDailyScheduleForMovieId);

        Task<bool> MovieExistsAsync(int movieId);

    }
}
