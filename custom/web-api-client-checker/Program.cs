using System;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace web_api_client_checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var booksApi = new BooksApi();
            var usersApi = new UsersApi();
            try {
                foreach (var user in usersApi.GetUsers()) {
                    Console.WriteLine(user);
                }
                foreach (var book in booksApi.GetBooks()) {
                    Console.WriteLine(book);
                }
            } catch (Exception e) {
            	Console.WriteLine("Exception when calling api: " + e.Message);
            }
        }
    }
}
