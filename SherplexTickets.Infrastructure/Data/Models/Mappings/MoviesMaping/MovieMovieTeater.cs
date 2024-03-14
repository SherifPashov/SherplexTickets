using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping
{
    public class MovieMovieTheater
    {
        [Required]
        [Comment("The current Movie's Identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [Comment("The current Movie")]
        public Movie Movie { get; set; } = null!;


        [Required]
        [Comment("The current MovieTheater's Identifier")]
        public int MovieTheaterId { get; set; }

        [ForeignKey(nameof(MovieTheaterId))]
        [Comment("The current MovieTheater")]
        public MovieTheater MovieTheater { get; set; } = null!;
    }
}
