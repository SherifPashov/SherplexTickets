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

        /// <summary>
        /// Book All constants
        /// </summary>

        public static class BookConstants
        {
            //Title
            public const int BookTitleMinLength = 1;
            public const int BookTitleMaxLength = 100;

            //Author
            public const int BookAuthorMinLength = 4;
            public const int BookAuthorMaxLength = 70;

            //Description
            public const int BookDescriptionMinLength = 200;
            public const int BookDescriptionMaxLength = 5000;

            //Price
            public const string BookPriceMinValue = "1";
            public const string BookPriceMaxValue = "10000";

            //Page
            public const double BookPageMinValue = 1;
            public const double BookPageMaxValue = 10000;

            //PublishingHouse
            public const int BookPublishingHouseMinLength = 1;
            public const int BookPublishingHouseMaxLength = 70;

            //YearPublished
            public const int BookYearPublishedMinRange = 1;
            public const int BookYearPublishedMaxRange = 2024;

            //ImageUrl
            public const int BookImageUrlMinLength = 5;
            public const int BookImageUrlMaxLength = 200;
        }

        public static class BookReviewConstants
        {
            //Title
            public const int BookReviewTitleMinLength = 1;
            public const int BookReviewTitleMaxLength = 50;

            //Description
            public const int BookReviewDescriptionMinLength = 15;
            public const int BookReviewDescriptionMaxLength = 8000;

            //Description
            public const int BookReviewRateMinRange = 1;
            public const int BookReviewRateMaxRange = 10;
        }

        public static class BookStoreConstants
        {
            public const string DateTimeBookStoreFormat = "HH:mm";

            //Name
            public const int BookStoreNameMaxLength = 100;

            //Location
            public const int BookStoreLocationMinLength = 10;
            public const int BookStoreLocationMaxLength = 100;

            //Contact
            public const string BookStoreContactRegex = @"^(?:\\+359\\d{9}|\\d{10})$";

            //ImageUrl
            public const int BookStoreImageUrlMinLength = 5;
            public const int BookStoreImageUrlMaxLength = 500;
        }



    }
}
