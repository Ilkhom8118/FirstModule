using Cars_CRUD.Models;
using Cars_CRUD.Services;

namespace Cars_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrontEnd();
        }
        public static void FrontEnd()
        {
            var updateCarList = new List<Car>();
            var cars = new CarServices();
            string [] updatedMenu = new string [1];
            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. GetById");
                Console.Write("Choose: ");
                var option = int.Parse(Console.ReadLine());
                Car car;
                switch (option)
                {
                    case 1:
                        var res = AddCar();
                        cars.CarAdd(res);

                        break;
                    case 2:
                        Console.Write("Get Id Of Delete: ");
                        var id = Guid.Parse(Console.ReadLine());
                        if (cars.CarDelete(id) is false)
                        {
                            Console.WriteLine("Not Deleted !!!");
                        }
                        else
                        {
                            Console.WriteLine("Deleted !!!");
                        }
                        break;
                    case 3:
                        UpdateCar(updateCarList,updatedMenu);
                        cars.CarUpdate(updateCarList[0],updatedMenu);
                        updateCarList = new List<Car>();

                        break;
                    case 4:
                        var carss = cars.GetAll();
                        foreach (var cares in carss)
                        {
                            Console.WriteLine($"Id: {cares.Id}");
                            Console.WriteLine($"Model: {cares.Model}");
                            Console.WriteLine($"Year: {cares.Year}");
                            Console.WriteLine($"Color: {cares.Color}");

                        }
                        break;
                    case 5:
                        break;
                }
            }
        }
        public static Car AddCar()
        {
            var car = new Car();
            Console.Write("Enter Car Model: ");
            car.Model = Console.ReadLine();
            Console.Write("Enter Car Year: ");
            car.Year = int.Parse(Console.ReadLine());
            Console.Write("Enter Car Color: ");
            car.Color = Console.ReadLine();
            return car;
        }

        public static void UpdateCar(List<Car> updateCarList, string[] updateMenu)
        {
            var car = new Car();

            {
                Console.Write("Enter Id: ");
                car.Id = Guid.Parse(Console.ReadLine());

                Console.WriteLine("1. Model");
                Console.WriteLine("2. Year");
                Console.WriteLine("3. Color");
                Console.Write("Choose: ");
                var option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter Model Create: ");
                        car.Model = Console.ReadLine();
                        updateCarList.Add(car);
                        updateMenu[0] = "Model";

                        break;
                    case 2:
                        Console.Write("Enter Year Create: ");
                        car.Year = int.Parse(Console.ReadLine());
                        updateCarList.Add(car);
                        updateMenu[0] = "Year";
                        break;
                    case 3:
                        Console.Write("Enter Color Create: ");
                        car.Color =Console.ReadLine();
                        updateCarList.Add(car);
                        updateMenu[0] = "Color";
                        break;
                }
            }
        }
        public static void UpdateBool(bool tf)
        {
            var update = tf ? "Updated !" : "not Updated !";
            Console.WriteLine(update);
        }
        public static void GetAllCar()
        {

        }
    }
}
