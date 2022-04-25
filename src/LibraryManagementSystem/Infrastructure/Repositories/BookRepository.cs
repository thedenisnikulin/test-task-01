using Application.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Models;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
	private readonly LibraryDbContext _ctx;
	private readonly Mapper _mapper;

	public BookRepository(LibraryDbContext ctx, Mapper mapper)
	{
		_ctx = ctx;
		_mapper = mapper;
	}

	public async Task Add(Book book)
	{
		var bookDataModel = _mapper.Map<BookDataModel>(book);
		await _ctx.Books.AddAsync(bookDataModel);
	}

	public async Task Delete(Guid id)
	{
		var bookDataModel = await _ctx.Books.FindAsync(id);
		_ctx.Books.Remove(bookDataModel);
	}

	public Task<IEnumerable<Book>> GetAllBooks()
	{
		return Task.FromResult(_ctx
			.Books
			.ProjectTo<Book>(_mapper.ConfigurationProvider)
			.ToList()
			.AsEnumerable());
	}

	public async Task<Book> GetBook(Guid id)
	{
		return _mapper.Map<Book>(await _ctx.Books.FindAsync(id));
	}

	public async Task Update(Book book)
	{
		var updatedBook = _mapper.Map<BookDataModel>(book);
		var trackedBook = await _ctx.Books.FindAsync(updatedBook.Id);

		_ctx.Entry(trackedBook).CurrentValues.SetValues(updatedBook);
	}

	public async Task Save()
	{
		await _ctx.SaveChangesAsync();
	}
}
