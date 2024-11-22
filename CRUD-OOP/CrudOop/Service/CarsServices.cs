using CrudOop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOop.Service;

public class CarsServices
{
    private List<Cars> ListedCars;

    public CarsServices()
    {
        ListedCars = new List<Cars>();
        DataSeed();
    }

    public Cars Addedcar(Cars addingCar)
    {
        addingCar.Id = Guid.NewGuid();
        ListedCars.Add(addingCar);
        return addingCar;
    }

    public bool DeletedCar(Guid IdOfRemoverCar)
    {
        var trueFalse = false;

        foreach(var check in ListedCars)
        {
            if(check.Id == IdOfRemoverCar)
            {
                ListedCars.Remove(check);
                trueFalse = true;
                break;
            }
        }
        return trueFalse;
    }


    public bool UpdatedCar(Cars updatingCar)
    {
        for(var i = 0; i < ListedCars.Count; i++)
        {
            if (ListedCars[i].Id == updatingCar.Id)
            {
                ListedCars[i] = updatingCar;
                return true;
            }
        }
        return false;
    }


    public List<Cars> GetAllCars()
    {
        return ListedCars;
    }


    public Cars GetById(Guid IdOfOneCar)
    {
        foreach(var check in ListedCars)
        {
            if(check.Id == IdOfOneCar)
            {
                return check;
            }
        }
        return null;
    }
    public void DataSeed()
    {
        var firsrCarExample = new Cars()
        {
            Model = "BMW",
            RunMilage = 35000,
            color = "Dark Blue",
            Id = Guid.NewGuid(),
            OwnerAmount = 2,
            where = "Germany",
        };

        var secondCarExample = new Cars()
        {
            Model = "Merc",
            RunMilage = 35000,
            color = "Dark Blue",
            Id = Guid.NewGuid(),
            OwnerAmount = 2,
            where = "Germany",
        };

        var thirdCarExample = new Cars()
        {
            Model = "BMW",
            RunMilage = 35000,
            color = "Dark Blue",
            Id = Guid.NewGuid(),
            OwnerAmount = 2,
            where = "Germany",
        };
    }
}
