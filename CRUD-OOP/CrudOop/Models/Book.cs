namespace CrudOop.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime Date { get; set; }
    public int Page { get; set; }
    public string Description { get; set; }


    public Book(string title, string author, DateTime date, int page, string descr)
    {
        Title = title;
        Author = author;
        Date = date;
        Page = page;
        Description = descr;
    }


    public void ShowInfo()
    {
        Console.Write("Id" + Id);
    }
}
