using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;


namespace SherplexTickets.Infrastructure.Data.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(MovieDiscriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string URLImage { get; set; } = string.Empty;

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateViewed { get; set; }

        [Required]
        public DateTime MovieWhatchTime { get; set; }

        [Required]
        public double Rating { get; set; }

        public ICollection<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();

        public ICollection<Genre> Genres { get; set;} = new List<Genre>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
