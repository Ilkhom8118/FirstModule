using CRUD_Book.Models;

namespace CRUD_Book.Services;

public class BookServices
{
    private List<Book> books;
    public BookServices()
    {
        books = new List<Book>();
    }

    public void Add(Book added)
    {
        var id = Guid.NewGuid();
        added.Id = id;
        books.Add(added);
    }


    public void Delete(Guid id)
    {
        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                books.Remove(book);
            }
        }
    }
    public bool Update(Book obj)
    {
        var TF = false;
        for (var i = 0; i < books.Count; i++)
        {
            if (obj.Id == books[i].Id)
            {
                books[i] = obj;
                TF = true;
                break;
            }
        }
        return TF;
    }
    public Book GetById(Guid id)
    {
        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }
        return null;
    }
    public List<Book> GetAll()
    {
        return books;
    }
    public Book GetExpensiveBook()
    {
        Book bk = books[0];
        for (int i = 1; i < books.Count; i++)
        {
            if (books[i].Price > bk.Price)
            {
                bk = books[i];
            }
        }
        return bk;
    }
    public Book GetMostPagedBook()
    {
        Book bk = books[0];
        for (int i = 1; i < books.Count; i++)
        {
            if (books[i].PageNumber > bk.PageNumber)
            {
                bk = books[i];
            }
        }
        return bk;
    }
    public Book GetMostReadBook()
    {
        Book bk = books[0];
        for (int i = 1; i < books.Count; i++)
        {
            if (books[i].ReadersName.Count > bk.ReadersName.Count)
            {
                bk = books[i];
            }
        }
        return bk;
    }
    public List<Book> GetBooksByReaderName(string readerName)
    {
        List<Book> ListOfBooks = new List<Book>();
        for (var i = 0; i < books.Count; i++)
        {
            for (var j = 0; j < books[i].ReadersName.Count; j++)
            {
                if (books[i].ReadersName[j] == readerName)
                {
                    ListOfBooks.Add(books[i]);
                }
            }
        }
        return ListOfBooks;
    }
    public List<Book> GetBooksByAuthorName(string authorName)
    {
        List<Book> ListOfBook = new List<Book>();
        for (var i = 0; i < books.Count; i++)
        {
            for (var j = 0; j < books[i].AuthorsName.Count; j++)
            {
                if (books[i].AuthorsName[j] == authorName)
                {
                    ListOfBook.Add(books[i]);
                }
            }
        }
        return ListOfBook;
    }
    public void AddReaderToBook(Guid id, string readerName)
    {
        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                book.ReadersName.Add(readerName);
            }
        }
    }
    public void AddAuthorToBook(Guid id, string authorName)
    {
        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                book.AuthorsName.Add(authorName);
            }
        }
    }
}


//* GetExpensiveBook()
//* GetMostPagedBook()
//* GetMostReadBook()
//* GetBooksByReaderName(string readerName)
//* GetBooksByAuthorName(string authorName)
//* AddReaderToBook(Guid bookId, string readerName)
//* AddAuthorToBook(Guid bookId, string authorName)