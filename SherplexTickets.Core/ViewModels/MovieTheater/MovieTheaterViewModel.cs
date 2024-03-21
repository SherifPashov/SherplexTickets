using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Migrations;
using System.ComponentModel.DataAnnotations;

namespace SherplexTickets.Core.ViewModels.MovieTheater
{
    public class MovieTheaterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Contact { get; set; } = null!;

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<DailySchedulesTheaterViewModel> WeeklySchedules { get; set; } = null!;
    }
}
