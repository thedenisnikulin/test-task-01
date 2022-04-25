namespace Domain.Entities;

public class Book
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Genre { get; set; }
	public uint Year { get; set; }

	public Book(string title, string author, string genre, uint year)
	{
		Id = Guid.NewGuid();
		Title = title;
		Author = author;
		Genre = genre;
		Year = year;
	}
}
