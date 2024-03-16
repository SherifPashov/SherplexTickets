using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.BookConstants;

namespace SherplexTickets.Infrastructure.Data.Models.Books
{
    public class Book
    {
        [Key]
        [Comment("The current Book's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        [Comment("The current Book's Title")]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("The current Book's Author Identifier")]
        public int AuthorId { get; set; }

        [Required]
        [ForeignKey(nameof(AuthorId))]
        [Comment("The current Book's Author")]
        public Author Author { get; set; } = null!;

        [Required]
        [MaxLength(BookDescriptionMaxLength)]
        [Comment("The current Book's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The current Book's Pages Count")]
        public int Pages { get; set; }

        [Required]
        [Comment("The date on which the curent Book was published")]
        public int YearPublished { get; set; }

        [Required]
        [Comment("The current Book's CoverType's Identifier")]
        public int CoverTypeId { get; set; }

        [ForeignKey(nameof(CoverTypeId))]
        [Comment("The current Book's CoverType")]
        public CoverType CoverType { get; set; } = null!;

        [Required]
        [MaxLength(BookImageUrlMaxLength)]
        [Comment("The current Book's cover image url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<BookBookStore> BooksBookStores { get; set; } = new List<BookBookStore>();
        public ICollection<GenreGenreOfBook> GenresGenresOfBooks { get; set; } = new List<GenreGenreOfBook>();
        public ICollection<BookReview> Reviews { get; set; } = new List<BookReview>();
        public ICollection<BookCart> BooksCarts { get; set; } = new List<BookCart>();
    }
}
