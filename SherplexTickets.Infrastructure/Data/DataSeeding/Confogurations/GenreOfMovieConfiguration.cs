using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SherplexTickets.Infrastructure.Data.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Infrastructure.Data.DataSeeding.Confogurations
{
    internal class GenreOfMovieConfiguration : IEntityTypeConfiguration<GenreOfMovie>
    {
        public void Configure(EntityTypeBuilder<GenreOfMovie> builder)
        {
            var data = new DataSeed();

            builder.HasData(data.GenresOfMovies);
        }
    }
}
