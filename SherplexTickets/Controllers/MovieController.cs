using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.Services;
using SherplexTickets.Core.ViewModels.BookView;
using SherplexTickets.Core.ViewModels.MovieView;

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
        public async Task<IActionResult> All()
        {
            var allMovies = await movieService.AllAsync();


            return View(allMovies);
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
        public async Task<IActionResult> Search(string input)
        {
            if (input == null)
            {
                return RedirectToAction(nameof(All));
            }

            var searchedMovies = await movieService.SearchAsync(input);

            if (searchedMovies == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(searchedMovies);
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

    }
}
