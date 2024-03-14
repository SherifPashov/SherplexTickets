﻿using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieTeaterConstants;

namespace SherplexTickets.Infrastructure.Data.Models.MovieTheaters
{
    public class MovieTheater
    {
        [Key]
        [Comment("The current MovieTheater's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MovieTheaterNameMaxLength)]
        [Comment("The current MovieTheater's Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(MovieTheaterLocationMaxLength)]
        [Comment("The current MovieTheater's Location")]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("The current MovieTheater's Mobile Contact")]
        public string Contact { get; set; } = null!;

        [Required]
        [Comment("The current MovieTheater's Opening Time")]
        public DateTime OpeningTime { get; set; }

        [Required]
        [Comment("The current MovieTheater's Closing Time")]
        public DateTime ClosingTime { get; set; }

        [Required]
        [MaxLength(MovieTheaterImageUrlMaxLength)]
        [Comment("The current MovieTheater's Image Url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<MovieMovieTeater> MoviesMoviesTeaters { get; set; } = new List<MovieMovieTeater>();
    }
}
