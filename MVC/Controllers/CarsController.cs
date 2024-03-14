using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers;

public class CarsController : Controller
{
    private readonly IAllCars _allCars;
    private readonly ICarsCategory _allCategories;

    public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
    {
        _allCars = iAllCars;
        _allCategories = iCarsCat;
    }

    [HttpGet]
    [Route("Cars/Add")]
    public IActionResult Add()
    {
        // Возвращаем представление для добавления нового продукта
        return View();
    }

    [HttpPost]
    [Route("Cars/Add")]
    public IActionResult Add(Car car)
    {
        // Добавляем новый продукт

        car.Category = _allCategories.AllCategories.FirstOrDefault(c => c.Name == "Електромобілі");

        _allCars.AddCar(car);

        // Перенаправляем пользователя на страницу со списком продуктов
        return RedirectToAction("List");
    }

    [HttpGet]
    [Route("Cars/Delete")]
    public IActionResult Delete()
    {
        // Передаємо новий екземпляр моделі у представлення для видалення
        var viewModel = new RemoveCarViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("Cars/Delete")]
    public IActionResult Delete(string carName)
    {
        if (!string.IsNullOrEmpty(carName))
        {
            // Здійснюйте пошук автомобіля за назвою та видаліть його якщо він існує
            var carToDelete = _allCars.Cars.FirstOrDefault(c => c.Name == carName);
            if (carToDelete != null)
            {
                _allCars.RemoveCar(carToDelete.Id); // Припустимо, що у вас є метод для видалення автомобіля за його ідентифікатором
                return RedirectToAction("List");
            }
        }
        ModelState.AddModelError("", "Автомобіль з такою назвою не знайдено");

        // Якщо введені дані неправильні, поверніть ту саму сторінку з помилками
        return RedirectToAction("Delete");
    }

    [Route("Cars/List")]
    [Route("Cars/List/{category}")]
    public ViewResult List(string category)
    {
        string _category = category;
        IEnumerable<Car> cars = null;
        string currCategory = "";
        if (string.IsNullOrEmpty(category))
        {
            cars = _allCars.Cars.OrderBy(i => i.Id);
        }
        else
        {
            if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Електромобілі")).OrderBy(i => i.Id);
                currCategory = "Електромобілі";
            }
            else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Класичні авто")).OrderBy(i => i.Id);
                currCategory = "Класичні авто";
            }


        }

        var carObj = new CarsListViewModel
        {
            allCars = cars,
            currCategory = currCategory
        };

        ViewBag.Title = "Сторінка з автомобілями";

        return View(carObj);
    }

}
