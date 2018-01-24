using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paperlib.Models;

namespace paperlib.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           	putSessionToViewData();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
           	putSessionToViewData();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
           	putSessionToViewData();
            return View();
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
