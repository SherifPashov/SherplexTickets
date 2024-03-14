using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SherplexTickets.Infrastructure.Data.Models.Books
{
    public class CoverType
    {
        [Key]
        [Comment("The current CoverType's Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The current CoverType's Name")]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}