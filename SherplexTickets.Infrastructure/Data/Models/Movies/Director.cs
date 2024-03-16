using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.DirectorConstants;
namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DirectorNameMaxLength)]
        public string FullName { get; set; } = string.Empty;
    }
}