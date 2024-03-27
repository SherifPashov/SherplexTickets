using SherplexTickets.Core.Enums;
using SherplexTickets.Core.ViewModels.Movies;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Core.ViewModels.QueryModels;
using SherplexTickets.Infrastructure.Data.Models.Movies;

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
        Task<Movie?> FindMovieIdAsync(int movieId);
        Task<MovieReview?> FindMovieReviewAsync(int reviewId);

        Task<IEnumerable<ActorViewModel>> AllActorsAsync(int movieId);

        Task<MovieViewModel> DetailsAsync(int movieId);

        Task<int> AddAsync(MovieAddViewModel movieForm);

        Task<MovieEditViewModel> EditGetAsync(int bookId);

        Task<int> EditPostAsync(MovieEditViewModel movieForm);

        Task<MovieDeleteViewModel> DeleteAsync(int movieId);

        Task DeleteConfirmedAsync(int bookId);

        Task<IEnumerable<MovieIndexViewModel>> GetTop10NewestPopularMovies();

        Task<int> AddMovieReviewAsync(MovieReviewAddViewModel movieReviewForm);

        Task<MovieReviewQueryServiceModel> AllMovieReviewsAsync(
            int movieId,
            string movieTitle,
            MovieReviewSorting sorting = MovieReviewSorting.Newest,
            int currentPage = 1,
            int reviewsPerPage = 4);

        Task<MovieReviewEditViewModel> EditMovieReviewGetAsync(int reviewId);

        Task<int> EditMovieReviewPostAsync(MovieReviewEditViewModel movieReveiwForm);

        Task<MovieReviewDeleteViewModel> DeleteMovieReviewAsync(int reveiwId);

        Task<int> DeleteMovieReviewConfirmedAsync(int reviewId);
    }
}
