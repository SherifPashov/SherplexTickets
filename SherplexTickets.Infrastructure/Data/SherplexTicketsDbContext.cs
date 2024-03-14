using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models;

namespace SherplexTickets.Infrastructure.Data
{
    public class SherplexTicketsDbContext : IdentityDbContext
    {
        public SherplexTicketsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<ActorMovie> ActorsMovies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ActorMovie>()
                .HasKey(ac => new { ac.ActorId, ac.MovieId });

            base.OnModelCreating(builder);

        }
    }
}
