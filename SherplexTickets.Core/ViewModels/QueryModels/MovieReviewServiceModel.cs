using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieReviewConstants;

namespace SherplexTickets.Core.ViewModels.QueryModels
{
    public class MovieReviewServiceModel
    {
        public int Id { get; set; }

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
