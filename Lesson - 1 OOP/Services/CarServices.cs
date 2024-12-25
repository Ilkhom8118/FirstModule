using Lesson___1_OOP.Models;
using System.Text.Json;

namespace Lesson___1_OOP.Services;

public class CarServices
{
    private string carsPath;
    private List<Car> cars;
    public CarServices()
    {
        cars = new List<Car>();
        carsPath = "../../../Data/Car.json";
        if (!File.Exists(carsPath))
        {
            File.WriteAllText(carsPath, "[]");
        }
        cars = GetAllCars();
    }
    private void SaveInformation(List<Car> cars)
    {
        var json = JsonSerializer.Serialize(cars);
        File.WriteAllText(carsPath, json);
    }
    public List<Car> GetAllCars()
    {
        var json = File.ReadAllText(carsPath);
        var file = JsonSerializer.Deserialize<List<Car>>(json);
        return file;
    }
    public Car AddCar(Car added)
    {
        added.Id = Guid.NewGuid();
        cars.Add(added);
        SaveInformation(cars);
        return added;
    }
    public Car GetById(Guid id)
    {
        foreach (var car in cars)
        {
            if (car.Id == id)
            {
                return car;
            }
        }
        return null;
    }
    public bool DeleteCar(Guid id)
    {
        var deleteId = GetById(id);
        if (deleteId is null)
        {
            return false;
        }
        cars.Remove(deleteId);
        SaveInformation(cars);
        return true;
    }
    public bool UpdateCar(Car obj)
    {
        var id = GetById(obj.Id);
        if (id is null)
        {
            return false;
        }
        cars[cars.IndexOf(id)] = obj;
        SaveInformation(cars);
        return true;
    }
}
