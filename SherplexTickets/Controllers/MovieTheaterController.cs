using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;

namespace SherplexTickets.Controllers
{
    public class MovieTheaterController : Controller
    {
        
        private readonly IMovieTheaterService movieTheaterService;

        public MovieTheaterController(IMovieTheaterService movieTheaterService)
        {
                this.movieTheaterService = movieTheaterService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allBookStores = await movieTheaterService.AllAsync();
            return View(allBookStores);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await movieTheaterService.MovieTheaterExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await movieTheaterService.DetailsAsync(id);
            return View(currentBook);
        }
    }
}
