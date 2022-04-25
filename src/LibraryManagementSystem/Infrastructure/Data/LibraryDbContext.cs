using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Models;

namespace Infrastructure.Data;

public class LibraryDbContext : DbContext
{
	public DbSet<BookDataModel> Books { get; set; }

	public LibraryDbContext(DbContextOptions options) : base(options) {}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
	}
}
