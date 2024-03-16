using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.GenreConstants;
namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class GenreOfMovie
    {
        [Key]
        [Comment("The current Movie Genre's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The current Movie Genre's Name")]
        public string Name { get; set; } = null!;

        public ICollection<GenreOfMovie> GenresMovies { get; set; } = new HashSet<GenreOfMovie>();
    }
}