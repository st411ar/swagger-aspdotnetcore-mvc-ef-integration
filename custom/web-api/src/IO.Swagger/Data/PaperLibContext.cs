using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;

namespace IO.Swagger.Data {
	public class PaperLibContext : DbContext {
		public PaperLibContext(DbContextOptions<PaperLibContext> options) : base(options) {}

		public DbSet<User> Users { get; set; }
		public DbSet<Book> Books { get; set; }
	}
}