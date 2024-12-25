using CRUD_Students.Models;
using CRUD_Students.Services;

namespace CRUD_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrontEnd();
        }
        public static void FrontEnd()
        {
            var students = new StudentServices();
            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. GetById");
                Console.Write("Choose: ");
                var option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        var res = AddSTND();
                        students.AddStudent(res);
                        break;
                    case 2:
                        Delete();
                        break;
                    case 3:
                        var update = Update();
                        students.Update(update);

                        break;
                    case 4:
                        var stnd = students.GetAll();
                        foreach (var student in stnd)
                        {
                            Console.WriteLine($"Id: {student.Id}");
                            Console.WriteLine($"First Name: {student.FirstName}");
                            Console.WriteLine($"Last Name: {student.LastName}");
                            Console.WriteLine($"Age: {student.Age}");
                            Console.WriteLine($"Location: {student.Location}");
                        }
                        break;
                    case 5:
                        Console.Write("Get By Id: ");
                        var id = Guid.Parse(Console.ReadLine());
                        var byId = students.GetById(id);
                        Console.WriteLine($"Id: {byId.Id}");
                        Console.WriteLine($"First Name: {byId.FirstName}");
                        Console.WriteLine($"Last Name: {byId.LastName}");
                        Console.WriteLine($"Age: {byId.Age}");
                        Console.WriteLine($"Location: {byId.Location}");
                        break;
                }
            }
        }
        public static Student AddSTND()
        {
            var student = new Student();
            Console.Write("First Name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            student.LastName = Console.ReadLine();
            Console.Write("Age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Location: ");
            student.Location = Console.ReadLine();
            return student;
        }
        public static void Delete()
        {
            var students = new StudentServices();
            Console.Write("Enter Id: ");
            var id = Guid.Parse(Console.ReadLine());
            if (students.Delete(id))
            {
                Console.WriteLine("Deleted !!!");
            }
            else
            {
                Console.WriteLine("Not Deleted !!!");
            }
        }
        public static Student Update()
        {

            var student = new Student();
            Console.Write("Enter Id: ");
            student.Id = Guid.Parse(Console.ReadLine());
            Console.Write("Enter First Name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            student.LastName = Console.ReadLine();
            Console.Write("Enter Age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Location: ");
            student.Location = Console.ReadLine();
            return student;
        }
        public static void GetAllStudent()
        {

        }
    }
}
