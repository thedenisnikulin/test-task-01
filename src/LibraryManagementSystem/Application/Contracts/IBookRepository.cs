using Domain.Entities;

namespace Application.Contracts;

public interface IBookRepository
{
	Task Add(Book book);
	Task Delete(Guid id);
	Task Update(Book book);
	Task<Book> GetBook(Guid id);
	Task<IEnumerable<Book>> GetAllBooks();
	Task Save();
}
