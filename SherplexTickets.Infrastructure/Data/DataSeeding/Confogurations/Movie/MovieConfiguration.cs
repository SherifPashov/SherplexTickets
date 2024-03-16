using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.Movies);
    }
}
