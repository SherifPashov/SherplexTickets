using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Infrastructure.Data.DataConstants
{
    public static class DataConstants
    {
        public static class MovieConstants 
        {
            //Movie Title
            public const int MovieTitleMinLength = 2;
            public const int MovieTitleMaxLength = 150;

            //Movie Discription
            public const int MovieDiscriptionMinLength = 5;
            public const int MovieDiscriptionMaxLength = 4000;
        }
        public static class  MovieReviewConstants
        {
            //MovieReview Title
            public const int MovieReviewTitleMinLength = 5;
            public const int MovieReviewTitleMaxLength = 50;

            //Comment Content
            public const int MovieReviewDescriptionMinLength = 15;
            public const int MovieReviewDescriptionMaxLength = 5000;
        }
        public static class ActorConstants
        {
            //Actor First Name
            public const int ActorFirstNameMinLength = 2;
            public const int ActorFirstNameMaxLength = 50;

            //Actor Last Name
            public const int ActorLastNameMinLength = 2;
            public const int ActorLastNameMaxLength = 50;
        }

       public static class GenreConstants
        {
            //Ganre Name
            public const int GenreNameMaxLength = 50;
            public const int GenreNameMinLength = 3;

            //Data Format
            public const string DataFormat = "dd/mm/yyyy HH:mm";
        }

        

        

    }
}
