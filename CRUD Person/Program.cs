using CRUD_Person.Models;
using CRUD_Person.Services;

namespace CRUD_Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrontEnd();
        }
        public static void FrontEnd()
        {
            var persons = new PersonServices();

            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. GetById");
                Console.Write("Choose: ");
                var option = int.Parse(Console.ReadLine());
                Console.Clear();
                Person person;
                switch (option)
                {
                    case 1:
                        person = AddPerson();
                        persons.PersonAdd(person);
                        break;
                    case 2:
                        Console.Write("Idni kiriting: ");
                        var id = Guid.Parse(Console.ReadLine());
                        if (persons.PersonDelete(id))
                        {
                            Console.WriteLine("Deleted !!!");
                        }
                        else
                        {
                            Console.WriteLine("Not deteled !!!");
                        }
                        break;
                    case 3:
                        UpdatePerson();
                        break;
                    case 4:
                        var personAll = persons.GetAll();

                        if (personAll is null)
                        {
                            Console.WriteLine("Empty !");
                        }
                        else
                        {
                            foreach (var personnn in personAll)
                            {
                                var str = $"ID : {personnn.Id}\nFirst Name : {personnn.FirstName}\nLast Name : {personnn.LastName}" +
                                    $"\nAge : {personnn.Age}";
                                Console.WriteLine(str);
                                Console.WriteLine();
                            }
                        }
                        break;
                    case 5:

                        Console.Write("Enter ID : ");
                        var personId = Guid.Parse(Console.ReadLine());
                        var personn = persons.GetByPersonId(personId);
                        if(personn is null)
                        {
                            Console.WriteLine("Error Occured !");
                        }
                        else
                        {
                            var str = $"ID : {personn.Id}\nFirst Name : {personn.FirstName}\nLast Name : {personn.LastName}\n" +
                                    $"\nAge : {personn.FirstName}";

                            Console.WriteLine(str);
                        }

                        break;
                    

                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static  Person AddPerson()
        {
            var person = new Person();

            Console.Write("Ism kiriting: ");
            person.FirstName = Console.ReadLine();
            Console.Write("Familiya kiriting: ");
            person.LastName = Console.ReadLine();
            Console.Write("Yosh kiriting: ");
            person.Age = int.Parse(Console.ReadLine());
            return person;
        }
        public static void UpdatePerson()
        {
            var persons = new PersonServices();
            var newPerson = new Person();
            Console.Write("Enter Updated Id : ");
            newPerson.Id = Guid.Parse(Console.ReadLine());
            Console.Write("Enter Person First Name  : ");
            newPerson.FirstName = Console.ReadLine();
            Console.Write("Enter Person Last Name  : ");
            newPerson.LastName = Console.ReadLine();
            Console.Write("Enter Person Age  : ");
            newPerson.Age = int.Parse(Console.ReadLine());
            var res = persons.PersonUpdate(newPerson);
            if (res is true)
            {
                Console.WriteLine("Updated !");
            }
            else
            {
                Console.WriteLine("Error Occured !");
            }
        }
    }
}
