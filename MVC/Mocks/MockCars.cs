using MVC.Interfaces;
using MVC.Models;

namespace MVC.Mocks;

public class MockCars : IAllCars
{
    private readonly ICarsCategory _carCategory = new MockCategory();

    public IEnumerable<Car> Cars
    {
        get
        {
            return new List<Car>
            {
                new Car
                {
                    Name = "Tesla Model S",
                    Description = "Швидкий автомобіль",
                    Image = "/img/Tesla.jpg",
                    Price = 45000,
                    IsFavourite = true,
                    Available = true,
                    Category = _carCategory.AllCategories.First()
                },
                new Car
                {
                    Name = "Ford Fiesta",
                    Description = "Тихій та спокійний",
                    Image = "/img/Ford.jpg",
                    Price = 11000,
                    IsFavourite = false,
                    Available = true,
                    Category = _carCategory.AllCategories.Last()
                },
                new Car
                {
                    Name = "BMW M3",
                    Description = "Зухвалий та стильний",
                    Image = "/img/BMW.jpg",
                    Price = 65000,
                    IsFavourite = true,
                    Available = true,
                    Category = _carCategory.AllCategories.Last()
                },
                new Car
                {
                    Name = "Mercedes C class",
                    Description = "Затишний та великий",
                    Image = "/img/Mercedes.jpg",
                    Price = 40000,
                    IsFavourite = false,
                    Available = false,
                    Category = _carCategory.AllCategories.Last()
                },
                new Car
                {
                    Name = "Nissan Leaf",
                    Description = "Тихий та економний",
                    Image = "/img/Nissan.jpg",
                    Price = 14000,
                    IsFavourite = true,
                    Available = true,
                    Category = _carCategory.AllCategories.First()
                }
            };
        }
    }

    public IEnumerable<Car> getFavCars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Car getObjectCars(int carId)
    {
        throw new NotImplementedException();
    }

    public void AddCar(Car car)
    {
        if (car != null)
        {

        }
    }

    public void RemoveCar(int carId)
    {

    }
}
