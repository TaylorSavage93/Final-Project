﻿using BookClubWeb.Models;
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

        public IActionResult ViewBook(int id)
        {
            var book = repo.GetBook(id);
            return View(book);
        }
        public IActionResult UpdateBook(int id)
        {
            Books book = repo.GetBook(id);
            if (book == null)
            {
                return View("BookNotFound");
            }
            return View(book);
        }

        public IActionResult UpdateBooksToDatatbase(Books books)
        {
            repo.UpdateBook(books);
            return RedirectToAction("ViewBook", new { id = books.Id });
        }
    }
}
