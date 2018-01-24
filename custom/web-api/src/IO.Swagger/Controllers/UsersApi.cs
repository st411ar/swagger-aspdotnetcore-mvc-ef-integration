/*
 * Paper Library Web API
 *
 * Paper Library Web API demonstrates integration of swagger with asp.net core + mvc + entity framework
 *
 * OpenAPI spec version: 0.2.2
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
    public class UsersApiController : Controller
    { 

        private readonly PaperLibContext context;

        public UsersApiController(PaperLibContext context) {
            this.context = context;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <remarks>Operation for creating new user</remarks>
        /// <param name="name">A string represents user name</param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/paperlib/users")]
        [ValidateModelState]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool?), description: "OK")]
        public virtual IActionResult CreateUser([FromQuery]string name)
        { 
            User user = new User();
            user.Name = name;
            context.Users.Add(user);
            context.SaveChanges();
            return new ObjectResult(true);
        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <remarks>Operation for deletting an user by its id</remarks>
        /// <param name="id">A string representing the id of an user</param>
        /// <response code="200">OK</response>
        [HttpDelete]
        [Route("/paperlib/users/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool?), description: "OK")]
        public virtual IActionResult DeleteUser([FromRoute][Required]int? id)
        { 
            User user = new User();
            user.Id = id.Value;
            context.Users.Remove(user);
            context.SaveChanges();
            return new ObjectResult(true);
        }

        /// <summary>
        /// Get an user
        /// </summary>
        /// <remarks>Operation for getting an user by its id</remarks>
        /// <param name="id">A string representing the id of an user</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/paperlib/users/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "OK")]
        public virtual IActionResult GetUser([FromRoute][Required]int? id)
        { 
            User user = context.Users
                    .Include(u => u.Role)
                    .Include(u => u.Books)
                    .Include(u => u.RentedBooks)
                    .SingleOrDefault(u => u.Id == id.Value);
            if (user != null) {
	            foreach (Book book in user.Books) {
	                book.Owner = null;
	                book.Reader = null;
	            }
	            foreach (Book book in user.RentedBooks) {
	                book.Owner = null;
	                book.Reader = null;
	            }
            }
            return new ObjectResult(user);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <remarks>Operation for getting all users</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/paperlib/users")]
        [ValidateModelState]
        [SwaggerOperation("GetUsers")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "OK")]
        public virtual IActionResult GetUsers()
        { 
        	List<User> users = context.Users
                    .Include(u => u.Role)
                    .ToList();
            return new ObjectResult(users);
        }

        /// <summary>
        /// Update an user
        /// </summary>
        /// <remarks>Operation for updating an user</remarks>
        /// <param name="id">A string representing the id of an user</param>
        /// <param name="name">A string represents user name</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/paperlib/users/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(bool?), description: "OK")]
        public virtual IActionResult UpdateUser([FromRoute][Required]int? id, [FromQuery]string name)
        { 
            var user = context.Users
                    .Where(u => u.Id == id.Value)
                    .FirstOrDefault();
            if (name != null) {
                user.Name = name;
            }
            context.SaveChanges();
            return new ObjectResult(true);
        }
    }
}
