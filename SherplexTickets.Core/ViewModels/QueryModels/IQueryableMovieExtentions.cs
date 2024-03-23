using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Core.ViewModels.QueryModels
{
    public static class IQueryableMovieExtentions
    {
        public static IQueryable<MovieAllViewModel> ProjectToMovieAllViewModel(this IQueryable<Movie> movies)
        {
            return movies.Select(m => new MovieAllViewModel()
            {
                Id = m.Id,
                Title = m.Title,
                URLImage = m.URLImage,
                YoutubeTrailerUrl = m.YoutubeTrailerUrl,
                Duration = m.Duration.ToString(),
                ReleaseDate = m.ReleaseDate.Year.ToString(),
            });
        }
    }
}
