using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.ViewModels.BookView
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Pages { get; set; }

        public int YearPublished { get; set; }

        public string CoverType { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
