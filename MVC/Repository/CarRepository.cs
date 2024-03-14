using Microsoft.EntityFrameworkCore;
using MVC.Interfaces;
using MVC.Models;

namespace MVC.Repository;

public class CarRepository : IAllCars
{
    private readonly AppDBContext appDBContext;

    public CarRepository(AppDBContext appDBContext)
    {
        this.appDBContext = appDBContext;
    }

    public IEnumerable<Car> Cars => appDBContext.Car.Include(c => c.Category);

    public IEnumerable<Car> getFavCars => appDBContext.Car.Where(p => p.IsFavourite).Include(c => c.Category);

    public Car getObjectCars(int carId) => appDBContext.Car.FirstOrDefault(p => p.Id == carId);
    public void AddCar(Car car)
    {
        if (car != null)
        {
            appDBContext.Car.Add(car);
            appDBContext.SaveChanges();
        }
    }

    public void RemoveCar(int carId)
    {
        var carToRemove = appDBContext.Car.FirstOrDefault(c => c.Id == carId);
        if (carToRemove != null)
        {
            appDBContext.Car.Remove(carToRemove);
            appDBContext.SaveChanges();
        }
    }
}
