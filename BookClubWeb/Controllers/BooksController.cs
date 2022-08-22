using Microsoft.AspNetCore.Mvc;

namespace BookClubWeb.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository repo;

        public BooksController(IBooksRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Books()
        {
            var books = repo.GetAllBooks();
            return View(books);
        }
    }
}
