using SherplexTickets.Core.Enums;
using SherplexTickets.Core.ViewModels.Movies;
using SherplexTickets.Core.ViewModels.MovieView;
using System.ComponentModel.DataAnnotations;

namespace SherplexTickets.Core.ViewModels.QueryModels
{
    public class AllMovieQueryModel
    {
        public int MoviePerPage { get; } = 2;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public MovieSorting Sorting { get; set; }

        public int TotalMoviesCount { get; set; }

        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Жанр")]
        public string Genre { get; set; } = null!;

        public IEnumerable<string> Genres { get; set; } = null!;

        public IEnumerable<MovieAllViewModel> Movies { get; set; } = new HashSet<MovieAllViewModel>();
    }
}
