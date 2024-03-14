using Microsoft.AspNetCore.Mvc;

namespace SherplexTickets.Controllers
{
    public class MovieTeaterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
