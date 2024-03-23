using SherplexTickets.Core.Enums;
using SherplexTickets.Core.ViewModels.Movies;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Core.ViewModels.QueryModels;

namespace SherplexTickets.Core.Contracts
{
    public interface IMovieService
    {
        Task<MovieQueryServiceModel> AllAsync(
            string? searchTerm,
            MovieSorting? sorting,
            string? genre = null,
            int currentPage = 1,
            int moviesPerPage = 8);

        Task<IEnumerable<GenreViewModel>> AllGenresAsync();

        Task<IEnumerable<GenreViewModel>> AllGenresAsync(int movieId);

        Task<bool> MovieExistsAsync(int movieId);

        Task<IEnumerable<ActorViewModel>> AllActorsAsync(int movieId);

        Task<MovieViewModel> DetailsAsync(int movieId);

        Task<int> AddAsync(MovieAddViewModel movieForm);

        Task<MovieEditViewModel> EditGetAsync(int bookId);

        Task<int> EditPostAsync(MovieEditViewModel movieForm);

        Task<MovieDeleteViewModel> DeleteAsync(int movieId);

        Task DeleteConfirmedAsync(int bookId);

    }
}
