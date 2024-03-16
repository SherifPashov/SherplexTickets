using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.GenreConstants;

namespace SherplexTickets.Infrastructure.Data.Models.Books
{
    public class GenreOfBook
    {
        [Key]
        [Comment("The current Movie Genre's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The current Movie Genre's Name")]
        public string Name { get; set; } = null!;

        public ICollection<GenreGenreOfBook> GenresMovies { get; set; } = new HashSet<GenreGenreOfBook>();
    }
}
