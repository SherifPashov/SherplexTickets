using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieTeaterConstants;

namespace SherplexTickets.Core.ViewModels.MovieTheater
{
    public class MovieTheaterAddViewModel
    {

        [Required]
        [StringLength(MovieTheaterNameMaxLength, MinimumLength = MovieTheaterNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(MovieTheaterLocationMaxLength, MinimumLength = MovieTheaterLocationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(MovieTheaterContactRegex, ErrorMessage = ContactErrorMessage)]
        public string Contact { get; set; } = null!;


        [Required]
        [DisplayFormat(DataFormatString = DateTimeHouFormat, ApplyFormatInEditMode = true)]
        public DateTime OpeningTime { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateTimeHouFormat, ApplyFormatInEditMode = true)]
        public DateTime ClosingTime { get; set; }

        [Required]
        [StringLength(MovieTheaterImageUrlMaxLength, MinimumLength = MovieTheaterImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [RegularExpression(MovieTheaterManagerEmailRegex, ErrorMessage = AddresErrorMessage)]
        public string TheaterManagerEmailName { get; set; } = string.Empty;

    }
}
