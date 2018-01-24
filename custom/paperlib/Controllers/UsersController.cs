﻿using System;
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
    public class UsersController : Controller
    {
    	private static UsersApi usersApi = new UsersApi();

        public IActionResult Index()
        {
           	putSessionToViewData();
            return View(usersApi.GetUsers());
        }

        public IActionResult Profile(int id)
        {
           	putSessionToViewData();
            return View(usersApi.GetUser(id));
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
