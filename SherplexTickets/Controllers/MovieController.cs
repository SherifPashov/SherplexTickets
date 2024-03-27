using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.Movies;
using SherplexTickets.Core.ViewModels.MovieView;
using SherplexTickets.Core.ViewModels.QueryModels;
using SherplexTickets.Extensions;

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


        [HttpGet]
        public async Task<IActionResult> AddReview(int movieId)
        {
            string userId = User.Id();

            var movieReviewForm = new MovieReviewAddViewModel()
            {
                MovieId = movieId,
                UserId = userId
            };
            return View(movieReviewForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(MovieReviewAddViewModel movieReviewForm)
        {
            if (!ModelState.IsValid)
            {
                return View(movieReviewForm);
            }

            int newMovieReviewId = await movieService.AddMovieReviewAsync(movieReviewForm);

            int movieId = movieReviewForm.MovieId;
            return RedirectToAction(nameof(AllReviews), new { id = movieId });
        }

        [HttpGet]
        public async Task<IActionResult> AllReviews (int movieId, [FromQuery] AllMovieReviewQueryModel model)
        {
            var movie = movieService.FindMovieIdAsync(movieId).Result;

            if (movie == null)
            {
                return BadRequest();
            }

            var allMovies = await movieService.AllMovieReviewsAsync(
                movieId,
                movie.Title,
                model.Sorting,
                model.CurrentPage,
                model.ReviewsPerPage);

            model.TotalMovieReviewsCount = allMovies.TotalReviewsCount;
            model.MovieReviews = allMovies.MovieReviews;
            model.MovieId = movie.Id;
            model.MovieTitle = movie.Title;

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> EditMovieReview(int reviewId)
        {
            var movieReview = await movieService.FindMovieReviewAsync(reviewId);
            if (movieReview == null)
            {
                return BadRequest();
            }

            if (User.Id() != movieReview.UserId)
            {
                return Unauthorized();
            }

            var movieReviewForm = await movieService.EditMovieReviewGetAsync(reviewId);

            return View(movieReviewForm);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovieReview(MovieReviewEditViewModel movieReviewForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (User.Id() != movieReviewForm.UserId)
            {
                return Unauthorized();
            }

            int movieId = await movieService.EditMovieReviewPostAsync(movieReviewForm);

            return RedirectToAction(nameof(AllReviews), new { movieId = movieId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMovieReview(int reviewId)
        {
            var movieReview = await movieService.FindMovieReviewAsync(reviewId);

            if (movieReview == null)
            {
                return BadRequest();
            }

            if (User.Id() != movieReview.UserId)
            {
                return Unauthorized();
            }
            var searchedMovieReview = await movieService.DeleteMovieReviewAsync(reviewId);

            return View(searchedMovieReview);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovieReviewConfirmend(int reviewId)
        {
            var movieReview = await movieService.FindMovieReviewAsync(reviewId);

            if (movieReview == null)
            {
                return BadRequest();
            }
            if (User.Id() != movieReview.UserId)
            {
                return Unauthorized();
            }

            var movieId = await movieService.DeleteMovieReviewConfirmedAsync(reviewId);

            return RedirectToAction(nameof(AllReviews), new { movieId = movieId });

        }
    }
}
