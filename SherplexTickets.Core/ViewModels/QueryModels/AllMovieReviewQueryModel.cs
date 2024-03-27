using SherplexTickets.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SherplexTickets.Core.ViewModels.QueryModels
{
    public class AllMovieReviewQueryModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

        public int ReviewsPerPage { get; } = 8;

        [Display(Name = "Сортиране")]
        public MovieReviewSorting Sorting { get; set; }

        public int TotalMovieReviewsCount { get; set; }

        public int CurrentPage { get; set; } = 1;

        public IEnumerable<MovieReviewServiceModel> MovieReviews { get; set; } = new List<MovieReviewServiceModel>();
    }
}
