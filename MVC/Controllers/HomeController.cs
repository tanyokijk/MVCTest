using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.Models;
using MVC.ViewModels;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }


        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavCars
            };
            return View(homeCars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
