using Cars_CRUD.Models;

namespace Cars_CRUD.Services;

public class CarServices
{
    private List<Car> cars;
    public CarServices()
    {
        cars = new List<Car>();
    }
    public Car CarAdd(Car added)
    {
       added.Id = Guid.NewGuid();
        cars.Add(added);
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
    public bool CarDelete(Guid id)
    {
        var carId = GetById(id);
        if (carId is null)
        {
            return false;
        }
        cars.Remove(carId);
        return true;
    }
    public bool CarUpdate(Car obj,string [] menu)
    {

        var id = GetById(obj.Id);
        if (id is null)
        {
            return false;
        }

        var index = cars.IndexOf(id);

        if (menu[0]== "Model")
        {
            cars[index].Model = obj.Model; 
        }
        else if (menu[0]== "Year")
        {
            cars[index].Year = obj.Year; 
        }
        else if (menu[0]== "Color")
        {
            cars[index].Color = obj.Color; 
        }


        return true;
    }
    public List<Car> GetAll()
    {
        return cars;
    }
}
