/*
 * Paper Library Web API
 *
 * Paper Library Web API demonstrates integration of swagger with asp.net core + mvc + entity framework
 *
 * OpenAPI spec version: 0.1.2
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;
using IO.Swagger.Models;

using IO.Swagger.Data;
using Microsoft.EntityFrameworkCore;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class BooksApiController : Controller
    { 

        private readonly PaperLibContext context;

        public BooksApiController(PaperLibContext context) {
            this.context = context;
        }

        /// <summary>
        /// Create new book
        /// </summary>
        /// <remarks>Operation for creating new book</remarks>
        /// <param name="name">A string represents book name</param>
        /// <param name="ownerId">A string represents book owner id</param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/paperlib/books")]
        [ValidateModelState]
        [SwaggerOperation("CreateBook")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool?), description: "OK")]
        public virtual IActionResult CreateBook([FromQuery]string name, [FromQuery]int? ownerId)
        { 
            Book book = new Book();
            book.Name = name;
            book.OwnerId = ownerId;
            context.Books.Add(book);
            context.SaveChanges();
            return new ObjectResult(true);
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <remarks>Operation for deletting a book by its id</remarks>
        /// <param name="id">A string representing book id</param>
        /// <response code="200">OK</response>
        [HttpDelete]
        [Route("/paperlib/books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteBook")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool?), description: "OK")]
        public virtual IActionResult DeleteBook([FromRoute][Required]int? id)
        { 
            Book book = new Book();
            book.Id = id.Value;
            context.Books.Remove(book);
            context.SaveChanges();
            return new ObjectResult(true);
        }

        /// <summary>
        /// Get a book
        /// </summary>
        /// <remarks>Operation for getting a book by its id</remarks>
        /// <param name="id">A string representing book id</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/paperlib/books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetBook")]
        [SwaggerResponse(statusCode: 200, type: typeof(Book), description: "OK")]
        public virtual IActionResult GetBook([FromRoute][Required]int? id)
        { 
            var book = context.Books
                    .Include(b => b.Owner)
                    .Include(b => b.Reader)
                    .SingleOrDefault(b => b.Id == id.Value);
            book.Owner.Books = null;
            if (book.Reader != null) {
                book.Reader.Books = null;
            }
            return new ObjectResult(book);
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <remarks>Operation for getting all books</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/paperlib/books")]
        [ValidateModelState]
        [SwaggerOperation("GetBooks")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Book>), description: "OK")]
        public virtual IActionResult GetBooks()
        { 
            List<Book> books = context.Books
                    .Include(b => b.Owner)
                    .Include(b => b.Reader)
                    .ToList();
            foreach (Book book in books) {
                book.Owner.Books = null;
                if (book.Reader != null) {
                    book.Reader.Books = null;
                }
            }
            return new ObjectResult(books);
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <remarks>Operation for updating a book</remarks>
        /// <param name="id">A string representing book id</param>
        /// <param name="name">A string represents book name</param>
        /// <param name="ownerId">A string represents book owner id</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/paperlib/books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateBook")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool?), description: "OK")]
        public virtual IActionResult UpdateBook([FromRoute][Required]int? id, [FromQuery]string name, [FromQuery]int? ownerId)
        { 
            var book = context.Books
                    .Where(b => b.Id == id.Value)
                    .FirstOrDefault();

            if (name != null) {
                book.Name = name;
            }
            if (ownerId != null) {
                book.OwnerId = ownerId;
            }
            context.SaveChanges();
            return new ObjectResult(true);
        }
    }
}
