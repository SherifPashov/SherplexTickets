using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.ViewModels.BookView;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieConstants;
namespace SherplexTickets.Core.ViewModels.MovieView
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string URLImage { get; set; } = string.Empty;

        public string ReleaseDate { get; set; } = string.Empty;

        public string DateViewedMovie { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;
        public string DirectorName { get; set; } = string.Empty;

        public string? ActorsName { get; set; } 

        public string? GenresName { get; set; } 
    }
}
