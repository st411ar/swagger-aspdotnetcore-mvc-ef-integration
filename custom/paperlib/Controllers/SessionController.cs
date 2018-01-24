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
    public abstract class SessionController : Controller
    {
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected void clearSession() {
           	HttpContext.Session.Clear();
        }

        protected int? getSessionUserId() {
        	return HttpContext.Session.GetInt32("userId");
        }

        protected int? getSessionUserRoleId() {
        	return HttpContext.Session.GetInt32("userRoleId");
        }

        protected void putSessionToViewData() {
       		ViewData["userId"] = getSessionUserId();
       		ViewData["userRoleId"] = getSessionUserRoleId();
        }

        protected void setUserSession(int userId, int userRoleId) {
			HttpContext.Session.SetInt32("userId", userId);
			HttpContext.Session.SetInt32("userRoleId", userRoleId);
        }
    }
}
