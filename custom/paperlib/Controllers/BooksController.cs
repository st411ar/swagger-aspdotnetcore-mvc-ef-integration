using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using paperlib.Models;

using IO.Swagger.Api;
using IO.Swagger.Model;

namespace paperlib.Controllers
{
    public class BooksController : Controller
    {
    	private static BooksApi booksApi = new BooksApi();

        public IActionResult Index()
        {
            ViewData["Message"] = "List of all books";
            return View(booksApi.GetBooks());
        }

        public IActionResult Profile(int id = 0)
        {
            Book book = null;
            string message = "There is no book with such id";

            if (id > 0) {
                book = booksApi.GetBook(id);
                if (book != null) {
                    message = $"Book {book.Name} profile page";
                }
            }

            ViewData["Message"] = message;
            return View(book);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
