using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;
    internal class GenreGenreOfMovieConfiguration : IEntityTypeConfiguration<GenreMovie>
    {
        public void Configure(EntityTypeBuilder<GenreMovie> builder)
        {
            var data = new DataSeed();
            builder.HasData(data.GenresGenreOfMovies);
        }
    }

