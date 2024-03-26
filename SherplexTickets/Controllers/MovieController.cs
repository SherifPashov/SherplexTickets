using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Core.ViewModels.QueryModels;

namespace SherplexTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;  
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await movieService.MovieExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await movieService.DetailsAsync(id);

            return View(currentBook);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllMovieQueryModel model)
        {
            var allSearchedMovies = await movieService.AllAsync(
                model.SearchTerm,
                model.Sorting,
                model.Genre,
                model.CurrentPage,
                model.MoviePerPage);

            model.TotalMoviesCount = allSearchedMovies.TotalMoviesCount;
            model.Movies = allSearchedMovies.Movies;

            var genre = await movieService.AllGenresAsync();

            var genresNames = genre.Select(a=>a.Name).ToArray();
            model.Genres = genresNames;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var bookForm = new MovieAddViewModel()
            {
                Genres = await movieService.AllGenresAsync(),
            };

            return View(bookForm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieAddViewModel movieForm)
        {

            if (!ModelState.IsValid || !movieForm.GenreIds.Any())
            {
                movieForm.Genres = await movieService.AllGenresAsync();
                return View(movieForm);
            }

            int newMovieId = await movieService.AddAsync(movieForm);

            return RedirectToAction(nameof(Details),new { Id = newMovieId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await movieService.MovieExistsAsync(id))
            {
                return BadRequest();
            }

            var bookForm = await movieService.EditGetAsync(id);
            return View(bookForm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(MovieEditViewModel movieForm)
        {
            if (movieForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid )
            {
                movieForm.Genres = await movieService.AllGenresAsync();
                var selectGenres = await movieService.AllGenresAsync(movieForm.Id);
                movieForm.SelectGenreIds = selectGenres.Select(sg=>sg.Id).ToList();


                return View(movieForm);
            }

            await movieService.EditPostAsync(movieForm);
            return RedirectToAction(nameof(Details), new {id=movieForm.Id});
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await movieService.MovieExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBook = await movieService.DeleteAsync(id);

            return View(searchedBook);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await movieService.MovieExistsAsync(id))
            {
                return BadRequest();
            }

            await movieService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }


    }
}
