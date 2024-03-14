using Microsoft.AspNetCore.Mvc;

namespace SherplexTickets.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
