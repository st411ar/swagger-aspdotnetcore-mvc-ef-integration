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
    public class UsersController : Controller
    {
    	private static UsersApi usersApi = new UsersApi();

        public IActionResult Index()
        {
            ViewData["Message"] = "List of all users";
            return View(usersApi.GetUsers());
        }

        public IActionResult Profile(int id = 0)
        {
            User user = null;
            string message = "There is no user with such id";

            if (id > 0) {
                user = usersApi.GetUser(id);
                if (user != null) {
                    message = $"User {user.Name} profile page";
                }
            }

            ViewData["Message"] = message;
            return View(user);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
