using System.ComponentModel.DataAnnotations.Schema;

namespace SherplexTickets.Infrastructure.Data.Models
{
    public class ActorMovie
    {
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;

        public int ActorId { get; set; }

        [ForeignKey(nameof(ActorId))]
        public Actor Actor { get; set; } = null!;
    }
}
