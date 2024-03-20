using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.MovieTheater;

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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieTheaterAddViewModel movieForm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            int newBookId = await movieTheaterService.AddAsync(movieForm);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await movieTheaterService.MovieTheaterExistsAsync(id))
            {
                return BadRequest();
            }

            var movieTheaterForm = await movieTheaterService.EditGetAsync(id);
            return View(movieTheaterForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieTheaterEditViewModel movieTheaterForm)
        {
            if (movieTheaterForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(movieTheaterForm);
            }

            await movieTheaterService.EditPostAsync(movieTheaterForm);
            return RedirectToAction(nameof(All));
        }
    }
}
