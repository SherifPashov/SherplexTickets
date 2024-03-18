using SherplexTickets.Core.ViewModels.BookView;
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
        Task<IEnumerable<GenreViewModel>> AllGenresAsync();
        Task<bool> MovieExistsAsync(int movieId);

        Task<IEnumerable<ActorViewModel>> AllActorsAsync(int movieId);

        Task<IEnumerable<GenreViewModel>> AllGenreAsync(int movieId);
        Task<MovieViewModel> DetailsAsync(int movieId);
        Task<IEnumerable<MovieAllViewModel>> SearchAsync(string input);

        Task<int> AddAsync(MovieAddViewModel movieForm);

    }
}
