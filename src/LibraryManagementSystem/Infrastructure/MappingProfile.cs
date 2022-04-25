using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.Models;

namespace Infrastructure;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Book, BookDataModel>();
		CreateMap<BookDataModel, Book>();
	}
}
