using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.ViewModels.MovieView
{
    public class ActorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

    }
}
