using Application.Contracts;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Queries;

public class GetBookQuery : IRequest<BookResponse>
{
	public Guid BookId { get; set; }

	public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookResponse>
	{
		private readonly IBookRepository _bookRepository;
		private readonly Mapper _mapper;

		public GetBookQueryHandler(IBookRepository bookRepository, Mapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<BookResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
		{
			return _mapper.Map<BookResponse>(await _bookRepository.GetBook(request.BookId));
		}
	}
}
