using SherplexTickets.Core.ViewModels.MovieTheater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.Contracts
{
    public interface IMovieTheaterService
    {
        Task<MovieTheaterViewModel?> GetMovieTheater(int theaterId);
        Task<bool> MovieTheaterExistsAsync(int theaterId);

        Task<IEnumerable<MovieTheaterAllViewModel>> AllAsync();
        Task<MovieTheaterViewModel?> DetailsAsync(int bookId);
    }
}
