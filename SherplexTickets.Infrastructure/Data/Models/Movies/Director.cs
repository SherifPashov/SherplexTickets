﻿using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.DirectorConstants;
namespace SherplexTickets.Infrastructure.Data.Models.Movies
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DirectorNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}