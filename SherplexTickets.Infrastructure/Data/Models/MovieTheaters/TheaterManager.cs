using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherplexTickets.Infrastructure.Data.Models.MovieTheaters
{
    public class TheaterManager
    {
        [Key]
        [Comment("The current ТheaterМanager's Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public ApplicationUser User { get; set; } = null!;

        public IEnumerable<MovieTheater> Theaters { get; set; } = new List<MovieTheater>();
    }
}
