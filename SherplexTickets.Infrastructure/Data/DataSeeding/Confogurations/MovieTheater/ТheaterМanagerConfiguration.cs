using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations.MovieTheater
{
    internal class ТheaterМanagerConfiguration : IEntityTypeConfiguration<ТheaterМanager>
    {
        public void Configure(EntityTypeBuilder<ТheaterМanager> builder)
        {
            var data = new DataSeed();
            builder.HasData(data.ТheaterМanagers);
        }
    }
}
