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
    public class AuthController : Controller
    {
    	private static AuthApi authApi = new AuthApi();

        public IActionResult LogIn(int userId, string userPassword) {

			bool isPasswordPassed = !String.IsNullOrEmpty(userPassword);
			if (isPasswordPassed) {
				bool isSignedIn = authApi.SignIn(userId, userPassword).Value;
				if (isSignedIn) {
		           	HttpContext.Session.SetInt32("userId", userId);
					return RedirectToAction("Profile", "Users", new {id = userId});
				} else {
		            ViewData["Message"] = "user id or password is incorrect";
				}
			}

           	putSessionToViewData();
        	return View();
        }

        public IActionResult LogOut() {
           	HttpContext.Session.Clear();
           	putSessionToViewData();
			return RedirectToAction("Index", "Home");
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
