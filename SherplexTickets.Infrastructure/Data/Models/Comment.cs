using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;
namespace SherplexTickets.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        [StringLength(CommentContentMaxLength)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public int MovieID { get; set; }

        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; } = null!;

        [Required]
        public int UserID { get; set; }
    }
}