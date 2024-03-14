using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data.Models.Mappings
{
    public class MovieMovieTeater
    {
        [Required]
        [Comment("The current Movie's Identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [Comment("The current Book")]
        public Movie Movie { get; set; } = null!;


        [Required]
        [Comment("The current MovieTeater's Identifier")]
        public int MovieTeaterId { get; set; }

        [ForeignKey(nameof(MovieTeaterId))]
        [Comment("The current MovieTeater")]
        public MovieMovieTeater MovieTeater { get; set; } = null!;
    }
}
