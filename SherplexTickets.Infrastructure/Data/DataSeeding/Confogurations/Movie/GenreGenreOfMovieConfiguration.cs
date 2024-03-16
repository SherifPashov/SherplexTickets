using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;
    internal class GenreGenreOfMovieConfiguration : IEntityTypeConfiguration<GenreGenreOfMovie>
    {
        public void Configure(EntityTypeBuilder<GenreGenreOfMovie> builder)
        {
            var data = new DataSeed();
            builder.HasData(data.GenresGenreOfMovies);
        }
    }

