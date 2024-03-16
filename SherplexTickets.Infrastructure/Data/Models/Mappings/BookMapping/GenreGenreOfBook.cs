using SherplexTickets.Infrastructure.Data.Models.Books;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping
{
    public class GenreGenreOfBook
    {
        
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public GenreOfBook Genre { get; set; } = null!;

        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
