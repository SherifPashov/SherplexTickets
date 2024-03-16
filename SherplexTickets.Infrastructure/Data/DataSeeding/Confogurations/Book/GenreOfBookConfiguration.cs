using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Books;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class GenreOfBookConfiguration : IEntityTypeConfiguration<GenreOfBook>
{
    public void Configure(EntityTypeBuilder<GenreOfBook> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.GenresOfBooks);
    }
}
