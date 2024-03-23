using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.GenreConstants;
namespace SherplexTickets.Core.ViewModels.Movies
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
