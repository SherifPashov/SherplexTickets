using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Infrastructure.Data.DataConstants
{
    public static class DataConstants
    {
        //Movie Title
        public const int MovieTitleMinLength = 2;
        public const int MovieTitleMaxLength = 150;

        //Movie Discription
        public const int MovieDiscriptionMinLength = 5;
        public const int MovieDiscriptionMaxLength = 4000;

        //Actor First Name
        public const int ActorFirstNameMinLength = 2;
        public const int ActorFirstNameMaxLength = 50;

        //Actor Last Name
        public const int ActorLastNameMinLength = 2;
        public const int ActorLastNameMaxLength = 50;

        //Comment Content
        public const int CommentContentMinLength = 5;
        public const int CommentContentMaxLength = 5000;

        //Ganre Name
        public const int GanreNameMaxLength = 50;
        public const int GanreNameMinLength = 3;

        //Data Format
        public const string DataFormat = "dd/mm/yyyy HH:mm";

    }
}
