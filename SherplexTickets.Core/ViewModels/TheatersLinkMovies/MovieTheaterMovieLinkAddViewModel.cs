using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants.MovieTheaterDailyScheduleForMovieConstants;

namespace SherplexTickets.Core.ViewModels.TheaterLinkMovie
{
    public class MovieTheaterMovieLinkAddViewModel
    {
        [Required]
        public int MovieTheaterId { get; set; }

        [Required]
        [Comment("The current Ticket's Price")]
        [Range(MovieTheaterDailyScheduleForMovieMinPrice, MovieTheaterDailyScheduleForMovieMaxPrice, ErrorMessage = RangePriceErrorMessage)]
        public decimal Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateTimeDefaultFormat, ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string ShowTimes { get; set; } = string.Empty;
        public IEnumerable<DailyMovieViewModel> Movies { get; set; } = new List<DailyMovieViewModel>();
    }
}
