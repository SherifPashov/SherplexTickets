using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieConstants;


namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class Movie
    {
        [Key]
        [Comment("The current Movie's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MovieTitleMaxLength)]
        [Comment("The current Movie's Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(MovieDiscriptionMaxLength)]

        [Comment("The current Movie's Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("The current Movie's URLImage")]
        public string URLImage { get; set; } = string.Empty;

        [Required]
        [Comment("The current Movie's Director Identifier")]
        public int DirectorId { get; set; }

        [Required]
        [ForeignKey(nameof(DirectorId))]
        public Director Director { get; set; } = null!;


        [Required]
        [Comment("The date on which the curent Movie was published")]
        public DateTime YearPublished { get; set; }

        [Required]
        [Comment("The current Movie's Movie Watch Time")]
        public int MovieWhatchTime { get; set; }

        public ICollection<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();

        public ICollection<GenreOfMovie> Genres { get; set; } = new List<GenreOfMovie>();

    }
}