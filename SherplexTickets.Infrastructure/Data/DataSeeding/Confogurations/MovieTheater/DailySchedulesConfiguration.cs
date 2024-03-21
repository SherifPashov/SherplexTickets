using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Mappings.MoviesMaping;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations.MovieTheater
{
    internal class DailyScheduleConfiguration : IEntityTypeConfiguration<MovieTheaterDailyScheduleForMovie>
    {
        public void Configure(EntityTypeBuilder<MovieTheaterDailyScheduleForMovie> builder)
        {
            var data = new DataSeed();

            builder.HasData(data.MovieTheatersDailyScheduleForMovies);
        }
    }
}
