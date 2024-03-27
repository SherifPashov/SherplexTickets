using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherplexTickets.Infrastructure.Data.Models.MovieTheaters
{
    public class ТheaterМanager
    {
        [Key]
        [Comment("The current ТheaterМanager's Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public IdentityUser User { get; set; } = null!;

        public IEnumerable<MovieTheater> Theaters { get; set; } = new List<MovieTheater>();
    }
}
