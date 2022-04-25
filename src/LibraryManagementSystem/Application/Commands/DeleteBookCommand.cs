using Application.Contracts;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Commands;

public class DeleteBookCommand : IRequest<Unit>
{
	public Guid BookId { get; set; }

	public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
	{
		private readonly IBookRepository _bookRepository;

		public DeleteBookCommandHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
		{
			await _bookRepository.Delete(request.BookId);
			return Unit.Value;
		}
	}
}
