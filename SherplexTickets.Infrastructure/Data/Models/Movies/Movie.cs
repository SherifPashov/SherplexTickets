using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieConstants;


namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class Movie
    {
        [Key]
        [Comment("The current Movie's Identifier")]
        public int MovieID { get; set; }

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
        [Comment("The date on which the curent Movie was published")]
        public DateTime YearPublished { get; set; }

        [Required]
        [Comment("The date on which the movie will be watched")]
        public DateTime DateViewedMovie { get; set; }

        [Required]
        [Comment("The current Movie's Movie Watch Time")]
        public DateTime MovieWhatchTime { get; set; }

        public ICollection<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public virtual ICollection<MovieReview> Comments { get; set; } = new List<MovieReview>();

    }
}
