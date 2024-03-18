using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.ActorConstants;

namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class Actor
    {
        [Key]
        [Comment("The current Actor's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ActorFullNameMaxLength)]
        [Comment("The current Actor's FirstName")]
        public string Name { get; set; } = string.Empty;


        public ICollection<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();
    }
}