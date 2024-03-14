using MVC.Models;

namespace MVC.ViewModels;

public class CarsListViewModel
{
    public IEnumerable<Car> allCars { get; set; }
    public string currCategory { get; set; }
}
