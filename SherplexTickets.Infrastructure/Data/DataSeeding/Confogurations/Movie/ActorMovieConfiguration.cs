using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class ActorMovieConfiguration : IEntityTypeConfiguration<ActorMovie>
{
    public void Configure(EntityTypeBuilder<ActorMovie> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.ActorsMovies);
    }
}
