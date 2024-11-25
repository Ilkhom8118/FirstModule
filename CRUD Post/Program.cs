using CRUD_Post.Models;

namespace CRUD_Post
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrontEndEvent();
        }
        public static void FrontEndEvent()
        {
            var listEvent = new EventSerives();
            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Read");
                Console.WriteLine("5. Guid");
                Console.WriteLine("6. Location");
                Console.WriteLine("7. Popular");
                Console.WriteLine("8. Tags");
                Console.WriteLine("9. Person");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    var
                    Console.Write("Enter Title: ");
                }
            }
        }

    }
}
