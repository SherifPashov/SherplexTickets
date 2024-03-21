using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.ViewModels.MovieTheater
{
    public class MovieTheaterDailyScheduleForMovieEditViewModel
    {
        public int Id {  get; set; }
        public string DayNameAndDate { get; set; } = string.Empty;

        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;

        public decimal Price { get; set; } 

        public string MovieImageUrl { get; set; } = string.Empty;
        public List<string> ShowTimeMovie { get; set; } = new List<string>();
    }
}
