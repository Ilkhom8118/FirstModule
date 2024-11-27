using CRUD_Book.Models;
using CRUD_Book.Services;

namespace CRUD_Book
{
    internal class Program
    {

        static void Main(string[] args)
        {
            FrontEnd();
        }
        public static void FrontEnd()
        {
            var serviceBook = new BookServices();
            while (true)
            {
                Console.WriteLine("1. Ma'lumot qo'shish");
                Console.WriteLine("2. Ma'lumot o'chirish");
                Console.WriteLine("3. Ma'lumot o'zgartirish");
                Console.WriteLine("4. Ma'lumot chiqarish");
                Console.WriteLine("5. Ma'lumot bitasini ko'rish");
                Console.WriteLine("6. Eng qimmat kitob");
                Console.WriteLine("7. Qalin kitobni chiqarish");
                Console.WriteLine("8. Eng ko'p o'qilgan kitoblar");
                Console.WriteLine("9. Kitobni o'qib chiqangan o'quvchisi");
                Console.WriteLine("10. Authori bir xil bo'lgan kitoblar");
                Console.WriteLine("11. O'qvuchi ismini qo'shish");
                Console.WriteLine("12. Kitobga author ismni qo'shish");
                var option = int.Parse(Console.ReadLine());
                Book book;
                switch (option)
                {
                    case 1:
                        book = FillAdd();
                        serviceBook.Add(book);
                        break;
                    case 2:
                        Console.Write("Ma'lumotni Idisini kiriting: ");
                        var id = Guid.Parse(Console.ReadLine());
                        serviceBook.Delete(id);
                        break;
                    case 3:
                        book = UpdateInfo();
                        serviceBook.Add(book);
                        break;
                    case 4:
                        List<Book> books = serviceBook.GetAll();
                        foreach (var obj in books)
                        {
                            Console.WriteLine($"Id: {obj.Id}");
                            Console.WriteLine($"Title: {obj.Title}");
                            Console.WriteLine($"PublicationDate: {obj.PublicationDate}");
                            Console.WriteLine($"Description: {obj.Description}");
                            Console.WriteLine($"PageNumber: {obj.PageNumber}");
                            Console.WriteLine($"Price: {obj.Price}");

                        }
                        break;
                }
            }

        }
        public static Book FillAdd()
        {
            var book = new Book();
            Console.Write("Sarlavha kiriting: ");
            book.Title = Console.ReadLine();
            book.PublicationDate = DateTime.Now.AddDays(-2);
            Console.Write("Tavsif kiriting: ");
            book.Description = Console.ReadLine();
            Console.Write("Kitoblar pageni kiriting: ");
            book.PageNumber = int.Parse(Console.ReadLine());
            Console.Write("Kitobning narxini kiriting: ");
            book.Price = int.Parse(Console.ReadLine());
            Console.Write("authorlar sonini kiriting: ");
            var count = int.Parse(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                Console.Write("Author ismini kiriting: ");
                var name = Console.ReadLine();
                book.AuthorsName.Add(name);
            }
            Console.Write("O'quvchilar soni: ");
            var oquchiSoni = int.Parse(Console.ReadLine());
            for (var i = 0; i < oquchiSoni; i++)
            {
                Console.Write("O'quvchi nomi: ");
                var name = Console.ReadLine();
                book.ReadersName.Add(name);
            }
            return book;
        }
        public static Book UpdateInfo()
        {
            var serviceBook = new BookServices();
            while (true)
            {
                var book = new Book();

                Console.WriteLine("Iltimos Idni kiriting: ");
                var id = Guid.Parse(Console.ReadLine());
                var bookUpdate = serviceBook.GetById(id);
                Console.WriteLine("1. Sarlavha");
                Console.WriteLine("2. Tavsif");
                Console.WriteLine("3. Page");
                Console.WriteLine("4. Narx");
                Console.WriteLine("5. Author ismlari");
                Console.WriteLine("6. O'quvchini ismi");
                var chose = int.Parse(Console.ReadLine());
                switch (chose)
                {
                    case 1:
                        Console.Write("Yangi sarlavha kiriting: ");
                        book.Title = Console.ReadLine();
                        UpdateBool(serviceBook.Update(bookUpdate));
                        break;
                    case 2:
                        Console.Write("Yangi Tavsif kiriting: ");
                        book.Description = Console.ReadLine();
                        UpdateBool(serviceBook.Update(bookUpdate));
                        break;
                    case 3:
                        Console.Write("Yangi page kiriting: ");
                        book.PageNumber = int.Parse(Console.ReadLine());
                        UpdateBool(serviceBook.Update(bookUpdate));
                        break;
                    case 4:
                        Console.Write("Yangi narx kiriting: ");
                        book.Price = int.Parse(Console.ReadLine());
                        UpdateBool(serviceBook.Update(bookUpdate));
                        break;
                    case 5:
                        var updatedBook = serviceBook.GetById(id);
                        if (updatedBook is null)
                        {
                            Console.WriteLine("Not updated");
                        }
                        else
                        {
                            Console.WriteLine("Enter Updated Author name : ");
                            var author = Console.ReadLine();
                            Console.WriteLine("Enter new author name :");
                            var newAuthorName = Console.ReadLine();
                            foreach (var name in updatedBook.AuthorsName)
                            {
                                if (name == author)
                                {
                                    var index = updatedBook.AuthorsName.IndexOf(author);
                                    updatedBook.AuthorsName[index] = newAuthorName;
                                }
                            }
                        }
                        break;
                    case 6:
                        var readNameUpdate = serviceBook.GetById(id);
                        if (readNameUpdate is null)
                        {
                            Console.WriteLine("Not Updated");
                        }
                        else
                        {
                            Console.WriteLine("Enter Updated Author name : ");
                            var author = Console.ReadLine();
                            Console.WriteLine("Enter new author name :");
                            var newReaderName = Console.ReadLine();
                            foreach (var name in readNameUpdate.AuthorsName)
                            {
                                if (name == author)
                                {
                                    var index = readNameUpdate.ReadersName.IndexOf(author);
                                    readNameUpdate.ReadersName[index] = newReaderName;
                                }
                            }
                        }
                        break;
                }
            }
        }
        static void UpdateBool(bool TF)
        {
            string boolean = TF ? "Updated" : "Not updated";
            Console.WriteLine(boolean);
        }
    }
}

