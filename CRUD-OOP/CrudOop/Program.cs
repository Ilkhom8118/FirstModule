namespace CrudOop.Student
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FrondEnd();
        }
        //public static void FrondEnd()
        //{
        //    var CarServices = new CarsServices();
        //    while (true)
        //    {
        //        Console.WriteLine("1. Add");
        //        Console.WriteLine("2. Delete");
        //        Console.WriteLine("3. Update");
        //        Console.WriteLine("4. GetAll");
        //        Console.WriteLine("5. GetById");
        //        var option = int.Parse(Console.ReadLine());



        //        if (option == 1)
        //        {

        //            var addCars = new Cars();
        //            Console.Write("Enter model: ");
        //            addCars.Model = Console.ReadLine();
        //            Console.Write("Enter Color: ");
        //            addCars.color = Console.ReadLine();
        //            Console.Write("Enter RunMilage: ");
        //            addCars.RunMilage = int.Parse(Console.ReadLine());
        //            Console.Write("Enter OwnerAmount: ");
        //            addCars.OwnerAmount = int.Parse(Console.ReadLine());

        //            CarServices.Addedcar(addCars);
        //        }
        //        else if (option == 2)
        //        {

        //            Console.Write("Enter id to delete");
        //            var id = Guid.Parse(Console.ReadLine());
        //            var res = CarServices.DeletedCar(id);
        //            Console.WriteLine(res);
        //        }
        //        else if (option == 3)
        //        {
        //            var addCars = new Cars();
        //            Console.Write("Enter id to update: ");
        //            addCars.Model = Console.ReadLine();
        //            Console.Write("Enter model: ");
        //            addCars.Model = Console.ReadLine();
        //            Console.Write("Enter Color: ");
        //            addCars.color = Console.ReadLine();
        //            Console.Write("Enter RunMilage: ");
        //            addCars.RunMilage = int.Parse(Console.ReadLine());
        //            Console.Write("Enter OwnerAmount: ");
        //            addCars.OwnerAmount = int.Parse(Console.ReadLine());
        //            CarServices.UpdatedCar(addCars);
        //        }
        //        else if (option == 4)
        //        {
        //            var Car = CarServices.GetAllCars();
        //            foreach (var car in Car)
        //            {
        //                var info = $"Id: {car.Id}, Model: {car.Model}," +
        //                   $" Color: {car.color}, Qancha yurgan: {car.RunMilage}, " +
        //                   $"Nechta odam xaydashi: {car.OwnerAmount} ";
        //                Console.WriteLine($"{info}");
        //            }
        //        }
        //        else if (option == 5)
        //        {

        //            Console.Write("Enter id to guid: ");
        //            var guid = Guid.Parse(Console.ReadLine());
        //            var carGuId = CarServices.GetById(guid);

        //        }
        //    }
        //}
        public static void FrondEnd()
        {
            var studentSerive = new StudentService();
            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. GetById");
                Console.Write("Enter: ");
                var option = Console.ReadLine();
                if (option == "1")
                {
                    var student = new Student();
                    Console.Write("O'quvchining ismi: ");
                    student.StudentOfName = Console.ReadLine();
                    Console.Write("O'quvchining yoshi: ");
                    student.StudentOfAge = int.Parse(Console.ReadLine());
                    Console.Write("Qaysi sinf o'qishi: ");
                    student.ClassName = Console.ReadLine();
                    Console.Write("Sinfda nechta o'quvchi o'qishi: ");
                    student.NumberOfStudents = int.Parse(Console.ReadLine());
                    Console.Write("Manzili: ");
                    student.Location = Console.ReadLine();

                    studentSerive.AddStudent(student);
                }
                else if (option == "2")
                {
                    Console.WriteLine("Enter id to delete: ");
                    var id = Guid.Parse(Console.ReadLine());
                    studentSerive.DeleteStudent(id);
                }
                else if (option == "3")
                {
                    var student = new Student();
                    Console.WriteLine("O'quvchining Id: ");
                    var id = Guid.Parse(Console.ReadLine());
                    Console.Write("O'quvchining ismi: ");
                    student.StudentOfName = Console.ReadLine();
                    Console.Write("O'quvchining yoshi: ");
                    student.StudentOfAge = int.Parse(Console.ReadLine());
                    Console.Write("Qaysi sinf o'qishi: ");
                    student.ClassName = Console.ReadLine();
                    Console.Write("Sinfda nechta o'quvchi o'qishi: ");
                    student.NumberOfStudents = int.Parse(Console.ReadLine());
                    Console.Write("Manzili: ");
                    student.Location = Console.ReadLine();

                    studentSerive.UpdateStudent(student);
                }
                else if (option == "4")
                {
                    var students = studentSerive.GetAllStudent();
                    foreach (var student in students)
                    {
                        var info = $"Id : {student.Id}, Name : {student.StudentOfName}, " +
                            $"Age : {student.StudentOfAge}, Class : {student.ClassName}" +
                            $" , Count : {student.StudentOfName}, Location : {student.Location}";
                        Console.WriteLine($"{info}");
                    }
                }
                else if (option == "5")
                {
                    Console.WriteLine("Enter id to get: ");
                    var id = Guid.Parse(Console.ReadLine());
                    var student = studentSerive.GetById(id);
                    var info = $"Id : {student.Id}, Name : {student.StudentOfName}, " +
                           $"Age : {student.StudentOfAge}, Class : {student.ClassName}" +
                           $" , Count : {student.StudentOfName}, Location : {student.Location}";
                    Console.WriteLine(info);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

}
