using Lesson___1_OOP.Models;
using Lesson___1_OOP.Services;

namespace Lesson___1_OOP;

internal class Program
{
    static void Main(string[] args)
    {
        FrontEnd();
    }

    public static void FrontEnd()
    {
        var car = new Car();
        var carService = new CarServices();
        while (true)
        {
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. GetAll");
            Console.WriteLine("5. GetById");
            Console.Write("Choose: ");
            var choose = Console.ReadLine();
            if (choose == "1")
            {
                CarAdd();
            }
            else if (choose == "2")
            {
                Console.Write("Enter Id: ");
                var id = Guid.Parse(Console.ReadLine());
                var getById = carService.GetById(id);
                if (carService.DeleteCar(id))
                {
                    Console.WriteLine("Deleted !!!");
                }
                else
                {
                    Console.WriteLine("Not Deleted !!!");
                }
            }
            else if (choose == "3")
            {
                CarUpdate();
            }
            else if (choose == "4")
            {
                AllCar();
            }
            else if (choose == "5")
            {
                GetByCar();
            }
        }
    }
    public static void CarAdd()
    {
        var car = new Car();
        var carService = new CarServices();
        Console.Write("Model: ");
        car.Model = Console.ReadLine();
        Console.Write("Name: ");
        car.Name = Console.ReadLine();
        Console.Write("Year: ");
        car.Year = int.Parse(Console.ReadLine());
        Console.Write("Speed: ");
        car.Speed = int.Parse(Console.ReadLine());
        Console.Write("Color: ");
        car.Color = Console.ReadLine();
        carService.AddCar(car);
    }
    public static void CarUpdate()
    {
        var car = new Car();
        var carService = new CarServices();
        Console.Write("Enter Id: ");
        car.Id = Guid.Parse(Console.ReadLine());
        Console.Write("Model: ");
        car.Model = Console.ReadLine();
        Console.Write("Name: ");
        car.Name = Console.ReadLine();
        Console.Write("Year: ");
        car.Year = int.Parse(Console.ReadLine());
        Console.Write("Speed: ");
        car.Speed = int.Parse(Console.ReadLine());
        Console.Write("Color: ");
        car.Color = Console.ReadLine();
        carService.UpdateCar(car);
    }
    public static void AllCar()
    {
        var car = new Car();
        var carService = new CarServices();
        var list = carService.GetAllCars();
        foreach (var item in list)
        {
            Console.WriteLine($"Id : {item.Id}");
            Console.WriteLine($"Model : {item.Model}");
            Console.WriteLine($"Name : {item.Name}");
            Console.WriteLine($"Year : {item.Year}");
            Console.WriteLine($"Speed : {item.Speed}");
            Console.WriteLine($"Color : {item.Color}");
        }
    }
    public static void GetByCar()
    {
        var car = new Car();
        var carService = new CarServices();
        Console.Write("Enter Id: ");
        var id = Guid.Parse(Console.ReadLine());
        var carById = carService.GetById(id);
        Console.WriteLine($"Id : {carById.Id}");
        Console.WriteLine($"Model : {carById.Model}");
        Console.WriteLine($"Name : {carById.Name}");
        Console.WriteLine($"Year : {carById.Year}");
        Console.WriteLine($"Speed : {carById.Speed}");
        Console.WriteLine($"Color : {carById.Color}");
    }
}
