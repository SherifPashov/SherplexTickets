using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Infrastructure.Data.Models.Carts
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public IdentityUser User { get; set; } = null!;

        public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
    }
}
