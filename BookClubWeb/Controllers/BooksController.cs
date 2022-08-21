using Microsoft.AspNetCore.Mvc;

namespace BookClubWeb.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
