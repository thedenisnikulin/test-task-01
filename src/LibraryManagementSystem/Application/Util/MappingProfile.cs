using Application.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Util;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<AddBookCommand, Book>();
		CreateMap<ChangeBookCommand, Book>();
		CreateMap<Book, BookResponse>();
	}
}
