using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Books;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class CoverTypeConfiguration : IEntityTypeConfiguration<CoverType>
{
    public void Configure(EntityTypeBuilder<CoverType> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.CoverTypes);
    }
}
