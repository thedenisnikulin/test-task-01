using Application.Contracts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands;

public class ChangeBookCommand : IRequest<Unit>
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Genre { get; set; }
	public uint Year { get; set; }

	public class ChangeBookCommandHandler : IRequestHandler<ChangeBookCommand, Unit>
	{
		private readonly IBookRepository _bookRepository;
		private readonly Mapper _mapper;

		public ChangeBookCommandHandler(IBookRepository bookRepository, Mapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(ChangeBookCommand request, CancellationToken cancellationToken)
		{
			await _bookRepository.Update(_mapper.Map<Book>(request));
			return Unit.Value;
		}
	}
}
