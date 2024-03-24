namespace SherplexTickets.Extensions
{
    public static class MovieTheaterHelper
    {
        public static bool IsMovieTheaterOpen(DateTime openingTime, DateTime closingTime)
        {
            var now = DateTime.Now;

            if (now.Hour < openingTime.Hour || now.Hour > closingTime.Hour)
            {
                return false;
            }

            if (now.Hour > openingTime.Hour && now.Hour < closingTime.Hour)
            {
                return true;
            }

            if (now.Hour == openingTime.Hour)
            {
                if (now.Minute >= openingTime.Minute)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (now.Minute <= closingTime.Minute)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

