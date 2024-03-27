namespace SherplexTickets.Core.ViewModels.QueryModels
{
    public class MovieReviewQueryServiceModel
    {
        public int TotalReviewsCount { get; set; }

        public IEnumerable<MovieReviewServiceModel> MovieReviews { get; set; } = new List<MovieReviewServiceModel>();
    }
}
