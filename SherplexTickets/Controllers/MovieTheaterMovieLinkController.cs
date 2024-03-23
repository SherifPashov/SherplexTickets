using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.Services;
using SherplexTickets.Core.ViewModels.TheaterLinkMovie;
using System.Globalization;

namespace SherplexTickets.Controllers
{
    public class MovieTheaterMovieLinkController : Controller
    {
        private readonly IMovieTheaterMovieLink movieTheaterMovieLinkService;

        public MovieTheaterMovieLinkController(IMovieTheaterMovieLink movieTheaterMovieLinkService)
        {
            this.movieTheaterMovieLinkService = movieTheaterMovieLinkService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await movieTheaterMovieLinkService.MovieTheaterDailyScheduleForMovieExistsAsync(id))
            {
                return BadRequest();
            }

            var movieTheaterLinkMovieForm = await movieTheaterMovieLinkService.EditGetAsync(id);
            return View(movieTheaterLinkMovieForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieTheaterDailyScheduleForMovieEditViewModel movieTheaterInformationForm)
        {
            if (movieTheaterInformationForm == null)
            {
                return BadRequest();
            }

            if (!TryParseTimes(movieTheaterInformationForm.ShowTimeMovie, out var times))
            {
                ModelState.AddModelError("ShowTimeMovie", "Невалиден формат на времената.");
                return View(movieTheaterInformationForm);
            }

            decimal price;

            if (!decimal.TryParse(movieTheaterInformationForm.Price.ToString(), out price))
            {
                ModelState.AddModelError(nameof(MovieTheaterDailyScheduleForMovieEditViewModel.Price), "Невалидна цена. Моля, въведете валидна ценова стойност.");
                return View(movieTheaterInformationForm);
            }


            var theaterId = await movieTheaterMovieLinkService.EditPostAsync(movieTheaterInformationForm);
            return RedirectToAction("Details", "MovieTheater", new { id = theaterId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await movieTheaterMovieLinkService.MovieTheaterDailyScheduleForMovieExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBook = await movieTheaterMovieLinkService.DeleteAsync(id);

            return View(searchedBook);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await movieTheaterMovieLinkService.MovieTheaterDailyScheduleForMovieExistsAsync(id))
            {
                return BadRequest();
            }

            var theaterId = await movieTheaterMovieLinkService.DeleteConfirmedAsync(id);
            return RedirectToAction("Details", "MovieTheater", new { id = theaterId });
        }

        [HttpHead]
        public async Task<IActionResult> Add()
        {
            var dailyForm = new MovieTheaterMovieLinkAddViewModel()
            {
                Movies = await movieTheaterMovieLinkService.GetAllMovie()
            };

            return View(dailyForm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieTheaterMovieLinkAddViewModel dailyForm)
        {
            if (await movieTheaterMovieLinkService.MovieTheaterDailyScheduleForMovieAddDateExistsAsync(
                dailyForm.MovieTheaterId,
                dailyForm.MovieId,
                dailyForm.Date))
            {
                ModelState.AddModelError("Date", "Филмът вече е добавен за тази дата.");
                return View(dailyForm);
            }

            int newLinkMovie = await movieTheaterMovieLinkService.AddAsync(dailyForm);
            return RedirectToAction("Details", "MovieTheater", new { id = dailyForm.MovieTheaterId });

        }
        public static bool TryParseTimes(string input, out TimeSpan[] times)
        {
            var parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            times = new TimeSpan[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!TimeSpan.TryParseExact(parts[i], "hh\\:mm", CultureInfo.InvariantCulture, out times[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
