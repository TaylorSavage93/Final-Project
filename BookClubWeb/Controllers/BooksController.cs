using LibraryInventoryWeb;
using LibraryInventoryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInventoryWeb.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository repo;

        public BooksController(IBooksRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Books(string SearchString)
        {
            var books = repo.GetAllBooks();

            ViewData["CurrentFilter"] = SearchString;
            books = from b in repo.GetAllBooks() select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.Title.Contains(SearchString));
            }
            return View(books);
        }
        public IActionResult ViewBook(double id)
        {
            var book = repo.GetBook(id);
            return View(book);
        }
        public IActionResult UpdateBook(double id)
        {
            Books book = repo.GetBook(id);
            if (book == null)
            {
                return View("BookNotFound");
            }
            return View(book);
        }

        public IActionResult UpdateBooksToDatabase(Books books)
        {
            repo.UpdateBook(books);
            return RedirectToAction("ViewBook", new { id = books.Id });
        }
        public IActionResult InsertBook()
        {
            var books = repo.AssignCategory();
            return View(books);
        }
        public IActionResult DeleteBook(Books books)
        {
            repo.DeleteBook(books);
            return RedirectToAction("Books");
        }
        public IActionResult InsertBooksToDatabase(Books booksToInsert)
        {
            repo.InsertBook(booksToInsert);
            return RedirectToAction("Books");
        }
    }
}
