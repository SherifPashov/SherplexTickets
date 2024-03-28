using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieReviewConstants;
using SherplexTickets.Infrastructure.Data.Models.IdentityModels;
namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class MovieReview
    {
        [Key]
        [Comment("The current Movie Review's Identifier")]
        public int Id { get; set; }

        [MaxLength(MovieReviewTitleMaxLength)]
        [Comment("The current Movie Review's Title")]
        public string Title { get; set; } = null!;

        [MaxLength(MovieReviewDescriptionMaxLength)]
        [Comment("The current Movie Review's Description")]
        public string Description { get; set; } = null!;

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
        public ApplicationUser User { get; set; } = null!;
    }
}
