using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherplexTickets.Infrastructure.Data.Models.Mappings
{
    public class GenreMovie
    {
        [Required]
        [Comment("The current Genre's Identifier")]
        public int GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        [Comment("The current Genre")]
        public Genre Genre { get; set; } = null!;

        [Required]
        [Comment("The current Movie's Identifier")]
        public int MovieId { get; set; }

        [Required]
        [Comment("The current Movie")]
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
