using CarRent.DAL.Interfaces;
using CarRent.Domain.ViewModels.Car;
using CarRent.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class CarController : Controller
    {
      private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public IActionResult GetCars()
        {
            var response = _carService.GetCars();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("GetCars", response.Data);
            }

            return View("Error", $"{response.Description}");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("AllCar");
            }
            Console.WriteLine(response.Description);
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) return PartialView();

            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel viewModel)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    await _carService.Create(viewModel, null);
                }
                else
                {
                    await _carService.Edit(viewModel.Id, viewModel);
                }
            }
            return RedirectToAction("GetCars");
        }

        [HttpGet]
        public async Task<ActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("GetCar", response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult AllCar()
        {
            var response =  _carService.GetCars();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("AllCar", response.Data);
            }

            return View("Error", $"{response.Description}");
        }


        [HttpGet]
        public async Task<ActionResult> GetCarSave(int id, bool isJson)
        {
            var response = await _carService.GetCar(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("Save", response.Data);
        }



        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _carService.GetTypes();
            return Json(types.Data);
        }
    }
}
