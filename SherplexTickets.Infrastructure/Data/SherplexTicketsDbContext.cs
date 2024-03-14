using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.Models;
using SherplexTickets.Infrastructure.Data.Models.Mappings;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data
{
    public class SherplexTicketsDbContext : IdentityDbContext
    {
        public SherplexTicketsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<MovieReview> Comments { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;

        public DbSet<ActorMovie> ActorsMovies { get; set; } = null!;
        public DbSet<GenreMovie> GenresMovies { get; set; } = null!;
        public DbSet<MovieMovieTeater> MoviesMoviesTeaters { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ActorMovie>()
                .HasKey(ac => new { ac.ActorId, ac.MovieId });

            builder.Entity<GenreMovie>()
                .HasKey(ac => new { ac.GenreId, ac.MovieId });

            builder.Entity<MovieMovieTeater>()
                .HasKey(ac => new { ac.MovieId, ac.MovieTeaterId });

            base.OnModelCreating(builder);

        }
    }
}
