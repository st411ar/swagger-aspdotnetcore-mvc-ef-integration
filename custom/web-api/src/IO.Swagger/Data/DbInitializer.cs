using IO.Swagger.Models;
using System;
using System.Linq;

namespace IO.Swagger.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PaperLibContext context)
        {
            context.Database.EnsureCreated();
            Console.WriteLine($"Users count: {context.Users.ToList().Count}");
            Console.WriteLine($"Books count: {context.Books.ToList().Count}");
        }
    }
}