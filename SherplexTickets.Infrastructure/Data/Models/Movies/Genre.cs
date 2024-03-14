using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.GenreConstants;
namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class Genre
    {
        [Key]
        [Comment("The current Genre's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The current Genre's Name")]
        public string Name { get; set; } = null!;

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}