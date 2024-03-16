using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Books;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.Authors);
    }
}
