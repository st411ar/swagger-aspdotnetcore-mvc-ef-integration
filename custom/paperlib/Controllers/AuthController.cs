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
    public class AuthController : SessionController
    {
    	private static AuthApi authApi = new AuthApi();

        public IActionResult LogIn(int userId, string userPassword) {
			if (!String.IsNullOrEmpty(userPassword)) {
				User user = authApi.SignIn(userId, userPassword);
				if (user != null) {
					setUserSession(user.Id.Value, user.RoleId.Value);
					return RedirectToAction("Profile", "Users", new {id = userId});
				} else {
		            ViewData["Message"] = "user id or password is incorrect";
				}
			}

           	putSessionToViewData();
        	return View();
        }

        public IActionResult LogOut() {
           	clearSession();
           	putSessionToViewData();
			return RedirectToAction("Index", "Home");
        }
    }
}
