using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.BookConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.ActorConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;

namespace SherplexTickets.Core.ViewModels.BookView
{
    public class BookAddViewModel
    {
        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ActorFullNameMaxLength, MinimumLength = ActorFullNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(BookPageMinValue, BookPageMaxValue, ErrorMessage = RangeErrorMessage)]
        public int Pages { get; set; }

        [Required]
        [Range(BookYearPublishedMinRange, BookYearPublishedMaxRange, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Year Published")]
        public int YearPublished { get; set; }

        [Required]
        [StringLength(BookImageUrlMaxLength, MinimumLength = BookImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Cover Type")]
        public int CoverTypeId { get; set; }
        public IEnumerable<CoverTypeViewModel> CoverTypes { get; set; } = new HashSet<CoverTypeViewModel>();


        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();
    }
}
