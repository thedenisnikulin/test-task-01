using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class BookDataModelConfiguration : IEntityTypeConfiguration<BookDataModel>
{
	public void Configure(EntityTypeBuilder<BookDataModel> builder)
	{

	}
}
