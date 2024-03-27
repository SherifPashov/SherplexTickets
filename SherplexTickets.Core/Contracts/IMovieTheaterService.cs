using SherplexTickets.Core.ViewModels.MovieTheater;

namespace SherplexTickets.Core.Contracts
{
    public interface IMovieTheaterService
    {
        Task<MovieTheaterViewModel?> GetMovieTheaterAsync(int movieTheaterId);

        Task<bool> MovieTheaterExistsAsync(int movieTheaterId);

        Task<IEnumerable<MovieTheaterDailyScheduleForMovieEditViewModel>> GetWeeklyScheduleForTheaterAsync(int movieTheaterId, DateTime todayDate);

        Task<IEnumerable<MovieTheaterAllViewModel>> AllAsync();

        Task<MovieTheaterViewModel?> DetailsAsync(int movieTheaterId, DateTime today);

        Task<int> AddAsync(MovieTheaterAddViewModel movieTheaterForm);

        Task<MovieTheaterEditViewModel> EditGetAsync(int movieTheaterId);

        Task<int> EditPostAsync(MovieTheaterEditViewModel movieTheaterForm);

        Task<MovieTheaterDeleteViewModel> DeleteAsync(int movieTheaterId);

        Task DeleteConfirmedAsync(int movieTheaterId);
    }
}
