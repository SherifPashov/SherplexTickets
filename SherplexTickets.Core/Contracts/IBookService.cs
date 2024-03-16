using SherplexTickets.Core.ViewModels.BookView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherplexTickets.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> AllAsync();
        Task<IEnumerable<CoverTypeViewModel>> AllCoverTypesAsync();
        Task<IEnumerable<GenreViewModel>> AllGenresAsync();
        Task<bool> BookExistsAsync(int bookId);
        Task<bool> GenreExistsAsync(int genreId);
        Task<bool> CoverTypeExistsAsync(int coverTypeId);
        Task<BookViewModel> DetailsAsync(int bookId);


    }
}
