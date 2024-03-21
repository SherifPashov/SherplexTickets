using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations.MovieTheater
{
    internal class DailyScheduleConfiguration : IEntityTypeConfiguration<DailyScheduleMovieTheater>
    {
        public void Configure(EntityTypeBuilder<DailyScheduleMovieTheater> builder)
        {
            var data = new DataSeed();

            builder.HasData(data.DailySchedules);
        }
    }
}
