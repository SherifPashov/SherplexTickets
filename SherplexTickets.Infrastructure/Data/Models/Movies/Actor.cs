using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.ActorConstants;

namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class Actor
    {
        [Key]
        [Comment("The current Actor's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ActorFirstNameMaxLength)]
        [Comment("The current Actor's FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(ActorLastNameMaxLength)]
        [Comment("The current Actor's LastName")]
        public string LastName { get; set; } = string.Empty;

        public ICollection<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();
    }
}