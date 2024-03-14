using MVC.Models;

namespace MVC.Interfaces;

public interface IAllCars
{
    IEnumerable<Car> Cars { get; }
    IEnumerable<Car> getFavCars { get; }
    Car getObjectCars(int carId);
    void AddCar(Car car);
    void RemoveCar(int carId);
}
