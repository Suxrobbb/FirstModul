namespace Car.Service;

internal class CarService
{

    private List<Car> cars;
    public CarService()
    {
        cars = new List<Car>();
        DataSeed();
    }

    public Guid AddCar(Car car)
    {
        car.Id = Guid.NewGuid();
        cars.Add(car);
        return car;
    }

    public bool DeleteCar(Guid restaurantId)
    {
        var exists = false;
        foreach (var car in cars)
        {
            if (car.Id == restaurantId)
            {
                cars.Remove(car);
                exists = true;
                break;
            }
        }

        return exists;
    }

    public bool UpdateCar(Car updatedCar)
    {
        for (var i = 0; i < cars.Count; i++)
        {
            if (cars[i].Id == updatedCar.Id)
            {
                cars[i] = updatedCar;
                return true;
            }
        }

        return false;
    }

    public Car GetById(Guid carId)
    {
        foreach (var car in cars)
        {
            if (car.Id == carId)
            {
                return car;
            }
        }

        return null;
    }

    public List<Car> GetAllCars()
    {
        return cars;
    }

    private void DataSeed()
    {
        var firstCatr = new Car()
        {
            CarId = Guid.NewGuid(),
            CarName = "Captiva",
            CarColor="qora",
            CarPrice=10000,
            CarKilometers=150000,
        };
        var secondCatr = new Car()
        {
            CarId = Guid.NewGuid(),
            CarName = "Malibu",
            CarColor="oq",
            CarPrice=250000,
            CarKilometers=80,
        };

        cars.Add(firstCatr);
        cars.Add(secondCatr);
    }
}



