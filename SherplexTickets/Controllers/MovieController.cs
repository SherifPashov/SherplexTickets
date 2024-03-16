using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.Services;

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
    }
}
