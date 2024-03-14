using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieReviewConstants;
namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class MovieReview
    {
        [Key]
        [Comment("The current Movie Review's Identifier")]
        public int Id { get; set; }

        [MaxLength(MovieReviewTitleMaxLength)]
        [Comment("The current Movie Review's Title")]
        public string? Title { get; set; } = null!;

        [MaxLength(MovieReviewDescriptionMaxLength)]
        [Comment("The current Movie Review's Description")]
        public string? Description { get; set; }

        [Required]
        [Comment("The current Movie Review's Rate")]
        public int Rate { get; set; }


        [Required]
        [Comment("The current Movie's Identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [Comment("The current Movie")]
        public Movie Movie { get; set; } = null!;

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public IdentityUser User { get; set; } = null!;
    }
}