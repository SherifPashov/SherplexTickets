using SherplexTickets.Core.ViewModels.MovieView;

namespace SherplexTickets.Core.ViewModels.QueryModels
{
    public class MovieQueryServiceModel
    {
        public int TotalMoviesCount { get; set; }
        public IEnumerable<MovieAllViewModel> Movies { get; set; } = new List<MovieAllViewModel>();

    }
}
