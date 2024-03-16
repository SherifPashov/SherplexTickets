using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;
using SherplexTickets.Infrastructure.Data.Models;
using SherplexTickets.Infrastructure.Data.Models.Books;
using SherplexTickets.Infrastructure.Data.Models.BookStores;
using SherplexTickets.Infrastructure.Data.Models.Carts;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data
{
    public class SherplexTicketsDbContext : IdentityDbContext
    {
        public SherplexTicketsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; } = null!;

        //Movie
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<GenreOfMovie> Genres { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;

        public DbSet<ActorMovie> ActorsMovies { get; set; } = null!;
        public DbSet<GenreGenreOfMovie> GenresMovies { get; set; } = null!;
        public DbSet<MovieMovieTheater> MoviesMoviesTheaters { get; set; } = null!;

        //Book

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<BookReview> BookReviews { get; set; } = null!;
        public DbSet<CoverType> CoverTypes { get; set; } = null!;
        public DbSet<GenreOfBook> GenreOfBooks { get; set; } = null!;
        public DbSet<BookStore> BookStores { get; set; } = null!;

        public DbSet<BookBookStore> BookBookStores { get; set; } = null!;
        public DbSet<GenreGenreOfBook> GenresGenresOfBooks { get; set; } = null!;
        public DbSet<BookCart> BookCarts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Movie
            builder.Entity<ActorMovie>()
                .HasKey(ac => new { ac.ActorId, ac.MovieId });

            builder.Entity<GenreGenreOfMovie>()
                .HasKey(ac => new { ac.GenreId, ac.MovieId });

            builder.Entity<MovieMovieTheater>()
                .HasKey(ac => new { ac.MovieId, ac.MovieTheaterId });

            //Book
            builder.Entity<BookBookStore>()
                .HasKey(ac => new { ac.BookId, ac.BookStoreId });

            builder.Entity<BookCart>()
                .HasKey(ac => new { ac.BookId, ac.CartId });

            builder.Entity<GenreGenreOfBook>()
                .HasKey(ac => new { ac.GenreId, ac.BookId });

            base.OnModelCreating(builder);

            //Configuration (Data Seeding)
            builder.ApplyConfiguration(new GenreOfBookConfiguration());
            builder.ApplyConfiguration(new CoverTypeConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new GenreGenreOfBookConfiguration());

            builder.ApplyConfiguration(new GenreOfMovieConfiguration());
            builder.ApplyConfiguration(new DirectorConfiguration());
            builder.ApplyConfiguration(new ActorConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new ActorMovieConfiguration());
            builder.ApplyConfiguration(new GenreGenreOfMovieConfiguration());
        }
    }
}