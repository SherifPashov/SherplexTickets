using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SherplexTickets.Core.Contracts;

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

    }
}
