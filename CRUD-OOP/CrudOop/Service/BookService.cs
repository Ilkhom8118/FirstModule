using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudOop.Models;
namespace CrudOop.Service
{
    internal class BookService
    {
        private List<Book> listOfBooks;


        public BookService()
        {
            
            listOfBooks = new List<Book>();
            DataSeed();
        }


        public Book AddBook(Book book)
        {

            book.Id = Guid.NewGuid();
            listOfBooks.Add(book);
            return book;
        }


        public Book UpdateBook(Book book)
        {
            for(int i = 0; i < listOfBooks.Count; i++)
            {
                if (listOfBooks[i].Id == book.Id)
                {
                    listOfBooks[i] = book;
                }
            }

            return book;

        }

        public Book DeleteBook(Guid Id)
        {
            foreach(var book in listOfBooks)
            {
                if(book.Id == Id)
                {
                    listOfBooks.Remove(book);
                    return book; 
                }
            }
            return null;
        }

        public Book GetBookById(Guid Id)
        {
            foreach(var book in listOfBooks)
            {
                if(book.Id == Id)
                {
                    return book;
                }
            }
            return null;
        }


        public void DataSeed()
        {
            Book book = new Book("Harry Potter", "John Smith", DateTime.Now, 200, "Magic book");
            Book book2 = new Book("Pyhon", "John Smith", DateTime.Now, 200, "Magic book");
            Book book3 = new Book("Asp.Net Core", "John Smith", DateTime.Now, 200, "Magic book");
            Book book4 = new Book("Va holaa", "John Smith", DateTime.Now, 200, "Magic book");
            Book book5 = new Book("Harry Potter", "John Smith", DateTime.Now, 200, "Magic book");


            listOfBooks.Add(book);
            listOfBooks.Add(book2);
            listOfBooks.Add(book3);
            listOfBooks.Add(book4);
            listOfBooks.Add(book5);
        }
    }
}
