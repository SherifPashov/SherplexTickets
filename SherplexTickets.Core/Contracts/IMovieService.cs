using SherplexTickets.Core.ViewModels.MovieView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieAllViewModel>> AllAsync();
    }
}
