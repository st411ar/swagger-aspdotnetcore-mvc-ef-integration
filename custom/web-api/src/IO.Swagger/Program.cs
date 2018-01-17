using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore;

using Microsoft.Extensions.DependencyInjection;
using IO.Swagger.Data;

namespace IO.Swagger
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
			var host = BuildWebHost(args);
            initDbContext(host);
    		host.Run();
        }

        /// <summary>
        /// Build Web Host
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Webhost</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://+:4999" /*, "https://+:5001" */)
                .Build();

        private static void initDbContext(IWebHost host) {
            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try {
                    var context = services.GetRequiredService<PaperLibContext>();
                    DbInitializer.Initialize(context);
                } catch (Exception ex) {
                    Console.WriteLine("DbInitializer exeption");
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
