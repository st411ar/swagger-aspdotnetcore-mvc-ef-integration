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
    public class HomeController : Controller
    {
    	private static BooksApi booksApi = new BooksApi();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Books()
        {
            ViewData["Message"] = "List of all books";
            return View(booksApi.GetBooks());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
