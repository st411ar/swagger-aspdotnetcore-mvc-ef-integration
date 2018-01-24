using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
           	putSessionToViewData();
            return View(booksApi.GetBooks());
        }

        public IActionResult Profile(int id)
        {
           	putSessionToViewData();
            return View(booksApi.GetBook(id));
        }

        public IActionResult Return(int id)
        {
            Book book = booksApi.GetBook(id);
            if (book != null) {
                if (book.ReaderId == HttpContext.Session.GetInt32("userId")) {
                    booksApi.ReturnBook(id);
                }
            }
            putSessionToViewData();
            return RedirectToAction("Profile", "Books", new {id = id});
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void putSessionToViewData() {
       		ViewData["userId"] = HttpContext.Session.GetInt32("userId");
        }
    }
}
