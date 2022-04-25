using Application.Contracts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands;

public class AddBookCommand : IRequest<Unit>
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Genre { get; set; }
	public uint Year { get; set; }

	public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Unit>
	{
		private readonly IBookRepository _bookRepository;
		private readonly Mapper _mapper;

		public AddBookCommandHandler(IBookRepository bookRepository, Mapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(AddBookCommand request, CancellationToken cancellationToken)
		{
			await _bookRepository.Add(_mapper.Map<Book>(request));
			return Unit.Value;
		}
	}
}
