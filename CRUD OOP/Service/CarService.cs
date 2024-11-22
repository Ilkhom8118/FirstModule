using CRUD_OOP.Model;

namespace CRUD_OOP.Service;

public class CarService
{
    private List<Car> ListCar;
    public CarService()
    {
        ListCar = new List<Car>();
    }
    public Car AddedCar(Car car)
    {
        car.Id = Guid.NewGuid();
        ListCar.Add(car);
        return car;
    }
    public bool DeleteCar(Guid carId)
    {
        var TF = false;
        foreach (var car in ListCar)
        {
            if (carId == car.Id)
            {
                ListCar.Remove(car);
                TF = true;
                break;
            }
        }
        return TF;
    }
    public bool UpdateCar(Car updateCar)
    {
        var TF = false;
        for (var i = 0; i < ListCar.Count; i++)
        {
            if (ListCar[i].Id == updateCar.Id)
            {
                ListCar[i] = updateCar;
                TF = true;
            }
        }
        return TF;
    }
    public Car GetById(Guid carId)
    {
        foreach (var car in ListCar)
        {
            if (car.Id == carId)
            {
                return car;
            }
        }
        return null;
    }
    public List<Car> GetAllCar()
    {
        return ListCar;
    }
}
