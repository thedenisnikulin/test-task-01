
namespace Application.Responses;

public class BookResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Genre { get; set; }
	public uint Year { get; set; }
}
