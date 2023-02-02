using CarRent.DAL.Interfaces;
//using CarRent.DAL.Repositories;
//using CarRent.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
/*        //private readonly ILogger<HomeController> _logger;

        private readonly ICarRepository _carRepository;

        public HomeController(ICarRepository carRepository)
        {
            //_logger = logger;
            //_carRepository = carRepository;
        }*/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OurCar()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

/*        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}