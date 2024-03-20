using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations
{
    internal class MovieTheatersConfiguration : IEntityTypeConfiguration<MovieTheater>
    {
        public void Configure(EntityTypeBuilder<MovieTheater> builder)
        {
            var data = new DataSeed();
            builder.HasData(data.MovieTheaters);

        }
    }
}
