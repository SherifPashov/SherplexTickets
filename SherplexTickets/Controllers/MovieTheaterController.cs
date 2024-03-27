using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Attributes;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.MovieTheater;

namespace SherplexTickets.Controllers
{
    public class MovieTheaterController : Controller
    {

        private readonly IMovieTheaterService movieTheaterService;
        private readonly ITheaterManagerService theaterManagerService;

        public MovieTheaterController(IMovieTheaterService movieTheaterService, ITheaterManagerService theaterManagerService)
        {
            this.movieTheaterService = movieTheaterService;
            this.theaterManagerService = theaterManagerService;
        }

        public async Task<bool> CheckIfUserExistsAsync(string username)
        {
            return await theaterManagerService
                .ExistsByIdAsync(username);

             
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

            var currentBook = await movieTheaterService.DetailsAsync(id, new DateTime(2024, 03, 22));
            return View(currentBook);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
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
        [MustBeTheaterManager]
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

        [HttpGet]
        [MustBeTheaterManager]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await movieTheaterService.MovieTheaterExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBook = await movieTheaterService.DeleteAsync(id);

            return View(searchedBook);
        }

        [HttpPost]
        [MustBeTheaterManager]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await movieTheaterService.MovieTheaterExistsAsync(id))
            {
                return BadRequest();
            }

            await movieTheaterService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
