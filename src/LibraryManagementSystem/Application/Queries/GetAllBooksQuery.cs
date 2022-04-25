using Application.Contracts;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Queries;

public class GetAllBooksQuery : IRequest<IEnumerable<BookResponse>>
{
	public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookResponse>>
	{
		private readonly IBookRepository _bookRepository;
		private readonly Mapper _mapper;

		public GetAllBooksQueryHandler(IBookRepository bookRepository, Mapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<BookResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
		{
			return _mapper.Map<List<BookResponse>>(await _bookRepository.GetAllBooks());
		}
	}
}
