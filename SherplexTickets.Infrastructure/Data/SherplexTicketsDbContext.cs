using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.DataSeeding;
using SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;
using SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations.MovieTheater;
using SherplexTickets.Infrastructure.Data.Models;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;

namespace SherplexTickets.Infrastructure.Data
{
    public class SherplexTicketsDbContext : IdentityDbContext
    {
        public SherplexTicketsDbContext(DbContextOptions options) : base(options)
        {
        }


        //Movie
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<GenreOfMovie> Genres { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;

        public DbSet<ActorMovie> ActorsMovies { get; set; } = null!;
        public DbSet<GenreGenreOfMovie> GenresMovies { get; set; } = null!;
        public DbSet<MovieReview> MovieReviews { get; set; } = null!;
        public DbSet<MovieTheaterDailyScheduleForMovie> MovieTheaterDailyScheduleForMovie { get; set; } = null!;
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Movie
            builder.Entity<ActorMovie>()
                .HasKey(ac => new { ac.ActorId, ac.MovieId });

            builder.Entity<GenreGenreOfMovie>()
                .HasKey(ac => new { ac.GenreId, ac.MovieId });

            builder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(a => a.Movies)
                .HasForeignKey(b => b.DirectorId)
                .IsRequired();

            builder.Entity<MovieTheaterDailyScheduleForMovie>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);

            base.OnModelCreating(builder);


            builder.ApplyConfiguration(new GenreOfMovieConfiguration());
            builder.ApplyConfiguration(new DirectorConfiguration());
            builder.ApplyConfiguration(new ActorConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new ActorMovieConfiguration());
            builder.ApplyConfiguration(new GenreGenreOfMovieConfiguration());

            builder.ApplyConfiguration(new MovieTheatersConfiguration());
            builder.ApplyConfiguration(new DailyScheduleConfiguration());
        }
    }
}