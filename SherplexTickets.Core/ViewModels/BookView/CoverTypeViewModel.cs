using System.ComponentModel.DataAnnotations;

namespace SherplexTickets.Core.ViewModels.BookView
{
    public class CoverTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
