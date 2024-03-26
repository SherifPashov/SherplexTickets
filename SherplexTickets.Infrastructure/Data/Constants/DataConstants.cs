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
        public const string DateTimeDefaultFormat = "dd.MM.yyyy";
        public const string DateTimeHouFormat = "HH:mm";

        //Length Error Message
        public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";

        //Range Error Message
        public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";

        public const string RangePriceErrorMessage = "{0} must be a number between {1} and {2}!";

        /// <summary>
        /// Movie All constants
        /// </summary>
        public static class MovieConstants 
        {
            // Title
            public const int MovieTitleMinLength = 2;
            public const int MovieTitleMaxLength = 150;

            // Discription
            public const int MovieDiscriptionMinLength = 5;
            public const int MovieDiscriptionMaxLength = 4000;


            //ImageUrl
            public const int MovieUrlMinLength = 5;
            public const int MovieUrlMaxLength = 400;
        }
        public static class  MovieReviewConstants
        {
            // Title
            public const int MovieReviewTitleMinLength = 5;
            public const int MovieReviewTitleMaxLength = 50;

            // Description
            public const int MovieReviewDescriptionMinLength = 15;
            public const int MovieReviewDescriptionMaxLength = 5000;

            //Rate
            public const int MovieReviewRateMinRange = 1;
            public const int MovieReviewRateMaxRange = 5;
        }
        public static class ActorConstants
        {
            //Name
            public const int ActorFullNameMinLength = 2;
            public const int ActorFullNameMaxLength = 80;

        }

        public static class GenreConstants
        {
            // Name
            public const int GenreNameMinLength = 3;
            public const int GenreNameMaxLength = 70;

        }

        public static class DirectorConstants
        {
            // Name
            public const int DirectorNameMinLength = 3;
            public const int DirectorNameMaxLength = 70;

        }

        public static class MovieTeaterConstants
        {

            //Name
            public const int MovieTheaterNameMinLength = 2;
            public const int MovieTheaterNameMaxLength = 100;

            //Location
            public const int MovieTheaterLocationMinLength = 5;
            public const int MovieTheaterLocationMaxLength = 300;

            //Contact
            public const string MovieTheaterContactRegex = @"^(?:\+359\d{9}|0\d{1}\s?\d{4}\s?\d{3})$";

            //ImageUrl
            public const int MovieTheaterImageUrlMinLength = 5;
            public const int MovieTheaterImageUrlMaxLength = 500;
        }

        public static class MovieTheaterDailyScheduleForMovieConstants
        {
            public const double MovieTheaterDailyScheduleForMovieMinPrice = 0.1;
            public const double MovieTheaterDailyScheduleForMovieMaxPrice = 100;

        }




    }
}
