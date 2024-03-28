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
        private readonly ITheaterManagerService theaterManager;
        private readonly UserManager<IdentityUser> userManager;

        public MovieTheaterController(
            IMovieTheaterService movieTheaterService,
            ITheaterManagerService theaterManager,
            UserManager<IdentityUser> _userManager)
        {
            this.movieTheaterService = movieTheaterService;
            this.theaterManager = theaterManager;
            this.userManager = _userManager; 
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
        public async Task<IActionResult> Add(MovieTheaterAddViewModel movieTheaterForm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = userManager
                .FindByEmailAsync(movieTheaterForm.TheaterManagerEmail).Result;

            if (user == null)
            {
                ModelState.AddModelError(nameof(movieTheaterForm.TheaterManagerEmail), "Потребителят с посочения имейл адрес не съществува.");
                return View();
            }

            int newBookId = await movieTheaterService.AddAsync(movieTheaterForm);
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
