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
    public class BooksController : SessionController {
    	private static BooksApi booksApi = new BooksApi();

        public IActionResult Delete(int id) {
            if (id > 0) {
                int? userId = getSessionUserId();
                if (userId.HasValue) {
                    Book book = booksApi.GetBook(id);
                    if (isAvailable(book)) {
                        int? userRoleId = getSessionUserRoleId();
                        if (mayDelite(userId, userRoleId, book)) {
                            booksApi.DeleteBook(id);
                        }
                    }
                }
            }
            putSessionToViewData();
            return RedirectToAction("Index", "Books");
        }

        public IActionResult Index() {
           	putSessionToViewData();
            return View(booksApi.GetBooks());
        }

        public IActionResult Order(int id) {
            if (id > 0) {
                int? userId = HttpContext.Session.GetInt32("userId");
                if (userId.HasValue) {
                    Book book = booksApi.GetBook(id);
                    if (isAvailable(book)) {
                        booksApi.UpdateBook(id, null, null, userId);
                    }

                }
            }
            putSessionToViewData();
            return RedirectToAction("Profile", "Books", new {id = id});
        }

        public IActionResult Profile(int id) {
            Book book = null;
            if (id > 0) {
                book = booksApi.GetBook(id);
            }
           	putSessionToViewData();
            return View(book);
        }

        public IActionResult Return(int id) {
            if (id > 0) {
                Book book = booksApi.GetBook(id);
                if (book != null
                    && book.ReaderId.HasValue
                    && book.ReaderId == HttpContext.Session.GetInt32("userId")
                ) {
                    booksApi.ReturnBook(id);
                }
            }
            putSessionToViewData();
            return RedirectToAction("Profile", "Books", new {id = id});
        }

        private static bool isAvailable(Book book) {
        	return book != null && !book.ReaderId.HasValue;
        }

        private static bool mayDelite(int? userId, int? userRoleId, Book book) {
            return userRoleId.HasValue 
                    && (userRoleId.Value == 1 || userRoleId.Value == 2) 
                    || book.OwnerId == userId;
        }
    }
}
