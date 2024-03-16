using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Mappings.BookMapping;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations;

internal class GenreGenreOfBookConfiguration : IEntityTypeConfiguration<GenreGenreOfBook>
{
    public void Configure(EntityTypeBuilder<GenreGenreOfBook> builder)
    {
        var data = new DataSeed();
        builder.HasData(data.GenresGenresOfBooks);
    }
}
