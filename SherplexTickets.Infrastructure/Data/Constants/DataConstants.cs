using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Infrastructure.Data.DataConstants
{
    public static class DataConstants
    {

        //Data Time Delaflt Format
        public const string DateTimeDefaultFormat = "dd/mm/yyyy HH:mm";

        //Length Error Message
        public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";

        //Range Error Message
        public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";

        public static class MovieConstants 
        {
            // Title
            public const int MovieTitleMinLength = 2;
            public const int MovieTitleMaxLength = 150;

            // Discription
            public const int MovieDiscriptionMinLength = 5;
            public const int MovieDiscriptionMaxLength = 4000;

            // Price
            public const string BookPriceMinValue = "1";
            public const string BookPriceMaxValue = "10000";

            //ImageUrl
            public const int BookImageUrlMinLength = 5;
            public const int BookImageUrlMaxLength = 200;
        }
        public static class  MovieReviewConstants
        {
            // Title
            public const int MovieReviewTitleMinLength = 5;
            public const int MovieReviewTitleMaxLength = 50;

            // Content
            public const int MovieReviewDescriptionMinLength = 15;
            public const int MovieReviewDescriptionMaxLength = 5000;

            //Rate
            public const int BookReviewRateMinRange = 1;
            public const int BookReviewRateMaxRange = 10;
        }
        public static class ActorConstants
        {
            // First Name
            public const int ActorFirstNameMinLength = 2;
            public const int ActorFirstNameMaxLength = 50;

            // Last Name
            public const int ActorLastNameMinLength = 2;
            public const int ActorLastNameMaxLength = 50;
        }

        public static class GenreConstants
        {
            // Name
            public const int GenreNameMaxLength = 50;
            public const int GenreNameMinLength = 3;

        }

        public static class MovieTeaterConstants
        {
            public const string DateTimeMovieTheaterFormat = "HH:mm";

            //Name
            public const int MovieTheaterNameMaxLength = 100;

            //Location
            public const int MovieTheaterLocationMinLength = 10;
            public const int MovieTheaterLocationMaxLength = 200;

            //Contact
            public const string MovieTheaterContactRegex = @"^(?:\\+359\\d{9}|\\d{10})$";

            //ImageUrl
            public const int MovieTheaterImageUrlMinLength = 5;
            public const int MovieTheaterImageUrlMaxLength = 500;
        }

        

        

    }
}
