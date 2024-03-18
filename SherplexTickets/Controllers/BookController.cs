using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.ViewModels.BookView;

namespace SherplexTickets.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allBooks = await bookService.AllAsync();
            return View(allBooks);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await bookService.DetailsAsync(id);

            return View(currentBook);
        }
        [HttpGet]
        //Only Admine
        public async Task<IActionResult> Add()
        {

            var bookForm = new BookAddViewModel()
            {
                Genres = await bookService.AllGenresAsync(),
                CoverTypes = await bookService.AllCoverTypesAsync(),
            };

            return View(bookForm);
        }

        [HttpPost]
        //Only Admine
        public async Task<IActionResult> Add(BookAddViewModel bookForm)
        {
            if (await bookService.GenreExistsAsync(bookForm.GenreId) == false)
            {
                ModelState.AddModelError(nameof(bookForm.GenreId), "Genre does not exist!");
            }
            else if (await bookService.CoverTypeExistsAsync(bookForm.CoverTypeId) == false)
            {
                ModelState.AddModelError(nameof(bookForm.CoverTypeId), "Cover Type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                bookForm.Genres = await bookService.AllGenresAsync();
                bookForm.CoverTypes = await bookService.AllCoverTypesAsync();
                return View(bookForm);
            }

            int newBookId = await bookService.AddAsync(bookForm);
            return RedirectToAction(nameof(Details),new { id = newBookId });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(string input)
        {
            if (input == null)
            {
                return RedirectToAction(nameof(All));
            }

            var searchedBooks = await bookService.SearchAsync(input);

            if (searchedBooks == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(searchedBooks);
        }

    }
}
