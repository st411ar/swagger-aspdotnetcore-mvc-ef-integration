/*
 * Paper Library Web API
 *
 * Paper Library Web API demonstrates integration of swagger with asp.net core + mvc + entity framework
 *
 * OpenAPI spec version: 0.4.0
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
    public class AuthApiController : Controller
    { 

        private readonly PaperLibContext context;

        public AuthApiController(PaperLibContext context) {
            this.context = context;
        }

        /// <summary>
        /// Sign In
        /// </summary>
        /// <remarks>Operation for signing in</remarks>
        /// <param name="id">A string represents user id</param>
        /// <param name="password">A string represents user password</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/paperlib/signin")]
        [ValidateModelState]
        [SwaggerOperation("SignIn")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "OK")]
        public virtual IActionResult SignIn([FromQuery]int? id, [FromQuery]string password)
        { 
			User user = null;
			if (id > 0 && !String.IsNullOrEmpty(password)) {
				string query = $"SELECT * FROM users WHERE id = {id.Value} AND password = '{password}'";
				List<User> users = context.Users
						.FromSql(query)
						.ToList();
				if (users.Count() == 1) {
					user = users[0];
				}
			}
            return new ObjectResult(user);
        }
    }
}
