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

namespace paperlib.Controllers {
    public class UsersController : SessionController {
    	private static UsersApi usersApi = new UsersApi();

        public IActionResult SignUp(string name, string password) {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(password)) {
                int? userId = getSessionUserId();
                if (!userId.HasValue) {
                    int? createdUserId = usersApi.CreateUser(name, password);
                    if (createdUserId.HasValue) {
                        return RedirectToAction("LogIn", "Auth", new {userId = createdUserId.Value, userPassword = password});
                    } else {
                        ViewData["Message"] = "user creation has been failed";
                    }
                }
            }
            putSessionToViewData();
            return View();
        }

        public IActionResult Delete(int id) {
            if (id > 0) {
                int? userId = getSessionUserId();
                int? userRoleId = getSessionUserRoleId();
                if (
                        userRoleId.HasValue && userRoleId.Value == 1
                        || userId.HasValue && userId.Value == id
                ) {
                    if (isDeletableUser(id)) {
                        usersApi.DeleteUser(id);
                    }
                }
            }
            return RedirectToAction("Index", "Users");
        }

        public IActionResult Edit(int id, string userName) {
            if (id > 0 && !String.IsNullOrEmpty(userName)) {
                int? userId = getSessionUserId();
                if (userId.HasValue && userId.Value == id) {
                    usersApi.UpdateUser(id, userName, null);
                }
            }
            return RedirectToAction("Profile", "Users", new {id = id});
        }

        public IActionResult EditRole(int id, int roleId) {
            if (id > 0 && 1 < roleId && roleId < 4) {
                int? userRoleId = getSessionUserRoleId();
                if (userRoleId.HasValue && userRoleId.Value == 1) {
                    usersApi.UpdateUser(id, null, roleId);
                }
            }
            return RedirectToAction("Profile", "Users", new {id = id});
        }

        public IActionResult Index() {
            putSessionToViewData();
            return View(usersApi.GetUsers());
        }

        public IActionResult Profile(int id) {
            putSessionToViewData();
            return View(usersApi.GetUser(id));
        }

        private static bool isDeletableUser(int id) {
            User user = usersApi.GetUser(id);
            return user.Books.Count == 0 && user.RentedBooks.Count == 0;
        }
    }
}
