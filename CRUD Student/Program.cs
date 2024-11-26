using CRUD_Student.Models;
using CRUD_Student.Services;

namespace CRUD_Student;

internal class Program
{
    static void Main(string[] args)
    {
        FrontEnd();
    }
    public static void FrontEnd()
    {
        var service = new StudentServices();
        var students = new List<Student>();
        while (true)
        {
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. GetAll");
            Console.WriteLine("5. GetById");
            Console.Write("Enter choose: ");
            var choose = int.Parse(Console.ReadLine());
            Console.Clear();
            Student stnd;
            switch (choose)
            {
                case 1:
                    stnd = FillStudent();
                    service.Add(stnd);
                    Console.Clear();
                    break;
                case 2:
                    Console.Write("Get Id Of Student");
                    var id = Guid.Parse(Console.ReadLine());
                    if (service.Delete(id))
                    {
                        Console.WriteLine("Deleted !!!");
                    }
                    else
                    {
                        Console.WriteLine("Not deleted !!!");
                    }
                    Console.Clear();
                    break;
                case 3:
                    UpdateStudent();
                    Console.Clear();
                    break;
                case 4:
                    List<Student> stnts = service.GetAll();
                    foreach (Student student in stnts)
                    {
                        Console.WriteLine($"Id: {student.Id}");
                        Console.WriteLine($"First: {student.FirstName}");
                        Console.WriteLine($"Last: {student.LastName}");
                        Console.WriteLine($"Age: {student.Age}");
                        Console.WriteLine($"Email: {student.Email}");
                        Console.WriteLine($"PhoneNumber: {student.PhoneNumber}");
                    }
                    Console.Clear();
                    break;
                case 5:

                    Console.Write("Id: ");
                    var guid = Guid.Parse(Console.ReadLine());
                    var studentPerson = service.GetById(guid);

                    Type type = studentPerson.GetType();
                    foreach (var property in type.GetProperties())
                    {
                        Console.WriteLine($"{property.Name}: {property.GetValue(studentPerson)}");
                    }
                    Console.Clear();
                    break;
            }
        }
    }
    public static Student FillStudent()
    {
        Student stnd = new Student();
        Console.Write("First Name: ");
        stnd.FirstName = Console.ReadLine();
        Console.Write("Last Name: ");
        stnd.LastName = Console.ReadLine();
        Console.Write("Age: ");
        stnd.Age = int.Parse(Console.ReadLine());
        Console.Write("Email: ");
        stnd.Email = Console.ReadLine();
        Console.Write("Phone Number: ");
        stnd.PhoneNumber = Console.ReadLine();
        return stnd;

    }
    public static void UpdateStudent()
    {
        var service = new StudentServices();
        while (true)
        {

            Console.Write("Enter Id: ");
            var id = Guid.Parse(Console.ReadLine());
            var stundent = service.GetById(id);
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Age");
            Console.WriteLine("4. Email");
            Console.WriteLine("5. PhoneNumber");
            Console.Write("Choose: ");
            var choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    stundent.FirstName = Console.ReadLine();
                    UpdateBool(service.Update(stundent));
                    break;
                case 2:
                    stundent.LastName = Console.ReadLine();
                    UpdateBool(service.Update(stundent));
                    break;
                case 3:
                    stundent.Age = int.Parse(Console.ReadLine());
                    UpdateBool(service.Update(stundent));
                    break;
                case 4:
                    stundent.Email = Console.ReadLine();
                    UpdateBool(service.Update(stundent));
                    break;
                case 5:
                    stundent.PhoneNumber = Console.ReadLine();
                    UpdateBool(service.Update(stundent));
                    break;
            }
        }
        static void UpdateBool(bool t)
        {
            string h = t ? "Updated" : "Not updated";
            Console.WriteLine(h);
        }

    }

}

