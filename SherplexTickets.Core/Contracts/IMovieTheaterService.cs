using SherplexTickets.Core.ViewModels.MovieTheater;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;

namespace SherplexTickets.Core.Contracts
{
    public interface IMovieTheaterService
    {
        Task<MovieTheaterViewModel?> GetMovieTheaterAsync(int theaterId);
        Task<bool> MovieTheaterExistsAsync(int theaterId);
        Task<IEnumerable<DailySchedulesTheaterViewModel>> GetWeeklyScheduleForTheaterAsync(int movieTheaterId);

        Task<IEnumerable<MovieTheaterAllViewModel>> AllAsync();
        Task<MovieTheaterViewModel?> DetailsAsync(int bookId);
        Task<int> AddAsync(MovieTheaterAddViewModel bookForm);
        Task<MovieTheaterEditViewModel> EditGetAsync(int movieTheaterId);
        Task<int> EditPostAsync(MovieTheaterEditViewModel movieTheaterForm);
    }
}
