using System.ComponentModel.DataAnnotations;
using static SherplexTickets.Infrastructure.Data.DataConstants.DataConstants;
namespace SherplexTickets.Infrastructure.Data.Models.MovieTheaters
{
    public class ShowTime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateTimeHouFormat)]
        public DateTime Time { get; set; }
    }

}
