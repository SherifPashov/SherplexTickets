using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data.Models.Mappings
{
    public class ActorMovie
    {
        [Required]
        [Comment("The current Movie Identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [Comment("The current Movie")]
        public Movie Movie { get; set; } = null!;

        [Comment("The current Actor Identifier")]
        public int ActorId { get; set; }

        [ForeignKey(nameof(ActorId))]
        [Comment("The current Actor")]
        public Actor Actor { get; set; } = null!;
    }
}
