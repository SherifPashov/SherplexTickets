namespace SherplexTickets.Core.ViewModels.TheaterLinkMovie
{
    public class MovieTheaterDailyScheduleForMovieEditViewModel
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string MovieTitle { get; set; } = string.Empty;
        
        public decimal Price { get; set; }

        public string MovieImageUrl { get; set; } = string.Empty;

        public string ShowTimeMovie { get; set; } = string.Empty;
    }
}
