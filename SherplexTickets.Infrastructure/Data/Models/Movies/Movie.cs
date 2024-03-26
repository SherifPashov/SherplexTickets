using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;


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
        [MaxLength(MovieUrlMaxLength)]
        public string URLImage { get; set; } = string.Empty;

        [Required]
        [Comment("The current Movie's YouTube Trailer Url")]
        [MaxLength(MovieUrlMaxLength)]
        public string YoutubeTrailerUrl { get; set; } =string.Empty;

        [Required]
        [Comment("The current Movie's Director Identifier")]
        public int DirectorId { get; set; }

        [Required]
        [ForeignKey(nameof(DirectorId))]
        public Director Director { get; set; } = null!;

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = DateTimeDefaultFormat, ApplyFormatInEditMode = true)]
        [Comment("The date on which the curent Movie release")]
        public DateTime ReleaseDate { get; set; }
        

        [Required]
        [Comment("The current Movie's Movie Watch Time")]
        public int Duration { get; set; }

        public ICollection<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();

        public ICollection<GenreGenreOfMovie> Genres { get; set; } = new List<GenreGenreOfMovie>();
        public ICollection<MovieReview> Reviews { get; set; } = new List<MovieReview>();
        public ICollection<MovieTheaterDailyScheduleForMovie> MovieTheaters { get; set; } = new List<MovieTheaterDailyScheduleForMovie>();

    }
}