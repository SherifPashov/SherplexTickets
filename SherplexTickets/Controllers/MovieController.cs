using Microsoft.AspNetCore.Mvc;

namespace SherplexTickets.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
