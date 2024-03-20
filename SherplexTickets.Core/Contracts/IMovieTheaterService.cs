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
        Task<IEnumerable<MovieTheaterAllViewModel>> AllAsync();
    }
}
