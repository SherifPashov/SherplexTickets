using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Movies;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.Directors);
    }
}
