using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;
namespace SherplexTickets.Infrastructure.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GanreNameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}