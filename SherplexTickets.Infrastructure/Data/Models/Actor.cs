using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;

namespace SherplexTickets.Infrastructure.Data.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ActorFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(ActorLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        public ICollection<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();
    }
}