using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.Actors);
    }
}
