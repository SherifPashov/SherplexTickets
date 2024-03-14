using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Books;
using SherplexTickets.Infrastructure.Data.Models.BookStores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.BookStoreConstants;

namespace SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping
{
    public class BookBookStore
    {

        [Required]
        [Comment("The current Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The current Book")]
        public Book Book { get; set; } = null!;


        [Required]
        [Comment("The current BookStore's Identifier")]
        public int BookStoreId { get; set; }

        [ForeignKey(nameof(BookStoreId))]
        [Comment("The current BookStore")]
        public BookStore BookStore { get; set; } = null!;
    }
}