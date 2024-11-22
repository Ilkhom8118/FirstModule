using CRUD_OOP.Model;
using CRUD_OOP.Service;

namespace CRUD_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrontEnd();
        }
        public static void FrontEnd()
        {
            var carService = new CarService();
            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. GetById");
                Console.Write("Enter: ");
                var option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    var car = new Car();
                    Console.Write("Enter Model: ");
                    car.Model = Console.ReadLine();
                    Console.Write("Enter Year: ");
                    car.Year = int.Parse(Console.ReadLine());
                    Console.Write("Car Milage: ");
                    car.CarMilage = int.Parse(Console.ReadLine());
                    Console.Write("Enter Position: ");
                    car.Position = Console.ReadLine();
                    Console.Write("Enter Color: ");
                    car.Color = Console.ReadLine();
                    carService.AddedCar(car);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter id to Delete");
                    var id = Guid.Parse(Console.ReadLine());
                    carService.DeleteCar(id);
                }
                else if (option == 3)
                {
                    var car = new Car();
                    Console.Write("Enter Id: ");
                    car.Id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter Model: ");
                    car.Model = Console.ReadLine();
                    Console.Write("Enter Year: ");
                    car.Year = int.Parse(Console.ReadLine());
                    Console.Write("Car Milage: ");
                    car.CarMilage = int.Parse(Console.ReadLine());
                    Console.Write("Enter Position: ");
                    car.Position = Console.ReadLine();
                    Console.Write("Enter Color: ");
                    car.Color = Console.ReadLine();
                    carService.UpdateCar(car);
                }
                else if (option == 4)
                {
                    var cars = carService.GetAllCar();
                    foreach (var car in cars)
                    {
                        var info = $"Id: {car.Id}, Model: {car.Model}, Year: {car.Year}" +
                            $" Car Milage: {car.CarMilage}, Position: {car.Position}, Color: {car.Color}";
                        Console.WriteLine($"{info}");
                    }
                }
                else if (option == 5)
                {
                    Console.Write("Enter id to get: ");
                    var id = Guid.Parse(Console.ReadLine());
                    var car = carService.GetById(id);
                    var info = $"Id: {car.Id}, Model: {car.Model}, Year: {car.Year}" +
                            $" Car Milage: {car.CarMilage}, Position: {car.Position}, Color: {car.Color}";
                    Console.WriteLine(info);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
