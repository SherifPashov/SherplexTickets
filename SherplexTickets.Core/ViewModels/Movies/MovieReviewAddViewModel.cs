using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieReviewConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;

namespace SherplexTickets.Core.ViewModels.Movies
{
    public class MovieReviewAddViewModel
    {

        [StringLength(MovieReviewTitleMaxLength, MinimumLength = MovieReviewTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [StringLength(MovieReviewDescriptionMaxLength, MinimumLength = MovieReviewDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(MovieReviewRateMaxRange, MovieReviewRateMinRange, ErrorMessage = RangeErrorMessage)]
        public int Rate { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}
