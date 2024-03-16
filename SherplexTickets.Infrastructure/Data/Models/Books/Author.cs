using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.AuthorConstants;

namespace SherplexTickets.Infrastructure.Data.Models.Books
{
    public class Author
    {
        [Key]
        [Comment("The current Authot's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        [Comment("The current Authot's Full Name")]
        public string FullName { get; set; } = string.Empty;
    }
}
