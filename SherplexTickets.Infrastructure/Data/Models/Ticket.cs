
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherplexTickets.Infrastructure.Data.Models
{
    public class Ticket
    {
        [Key]
        [Comment("The current Ticket's Identifier")]
        public int TicketId { get; set; }

        [Required]
        [Comment("The current Ticket's Price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("The current Ticket's PurchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Comment("The current Movie's Identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [Comment("The current Movie")]
        public virtual Movie Movie { get; set; } = null!;

        
    }
}
