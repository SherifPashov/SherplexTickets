using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Books;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            var data = new DataSeed();
            builder.HasData(data.Books);
        }
    }
}
