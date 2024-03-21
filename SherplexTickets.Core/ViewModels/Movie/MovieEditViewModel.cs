using SherplexTickets.Core.ViewModels.BookView;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieConstants;

namespace SherplexTickets.Core.ViewModels.MovieView
{
    public class MovieEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(MovieDiscriptionMaxLength, MinimumLength = MovieDiscriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(MovieUrlMaxLength, MinimumLength = MovieUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string URLImage { get; set; } = string.Empty;

        [Required]
        [StringLength(MovieUrlMaxLength, MinimumLength = MovieUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string YoutubeTrailerUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(DirectorConstants.DirectorNameMaxLength, MinimumLength = DirectorConstants.DirectorNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = DateTimeDefaultFormat, ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Actors")]
        public string ActorsName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Genre")]
        public IEnumerable<int> GenreIds { get; set; } = new List<int>();

        [Required]
        [Display(Name = "GenreSelect")]
        public IEnumerable<int> SelectGenreIds { get; set; } = new List<int>();

        public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();

    }
}
