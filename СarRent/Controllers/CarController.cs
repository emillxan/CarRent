﻿using Azure;
using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
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


        //[HttpGet]
        /*        public IActionResult GetCars()
                {
                    //var response = _carService.GetCars();
                    if (response.StatusCode == Domain.Enum.StatusCode.OK)
                    {
                        return View("GetCars", response.Data);
                    }

                    return View("Error", $"{response.Description}");
                }*/

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            int pageIndex = 0;
            int pageSize = 10;
            var result = await _carService.GetByPage(pageIndex, pageSize);
            return View(result.Data);
        }

        // [FromBody]

        [HttpPost]
        public JsonResult PostTest([FromBody] string carFilters)
        {
            return Json(carFilters);
        }

        [HttpPost]
        public async Task<IActionResult> GetCars([FromBody] string carFilters)
        {
            int pageIndex = 0; int pageSize = 10;
            //var result = await _carService.GetByPage(carFilters, pageIndex, pageSize);
            //return View(result.Data);
            return View('d');

/*            if (result.IsSuccess)
            {
                 // Возвращаем представление с данными о машинах
            }
            else
            {
                // Если возникла ошибка, отображаем сообщение об ошибке
                ViewBag.ErrorMessage = result.Description;
                return View("Error");
            }*/
        }


/*        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("AllCar");
            }
            Console.WriteLine(response.Description);
            return RedirectToAction("Index", "Home");
        }*/

        //public IActionResult Compare() => PartialView();

/*        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) return PartialView();

            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("Save", response.Data);
            }
            return PartialView();
        }*/

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel viewModel)
        {
            ModelState.Remove("Id");

            if (viewModel.Id == 0)
            {
                //await _carService.Create(viewModel, null);
            }
            else
            {
                await _carService.Edit(viewModel.Id, viewModel);
            }

            return RedirectToAction("AllCar");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel viewModel, IFormFile CarPhoto)
        {
            //await _carService.Create(viewModel, CarPhoto);

            return RedirectToAction("AllCar");
        }

        public async Task<IActionResult> DeletImg(long id)
        {
            return RedirectToAction("Save" + "/" + id);
        }

/*        [HttpGet]
        public async Task<ActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("GetCar", response.Data);
            }
            return View("Error", $"{response.Description}");
        }*/

/*        [HttpGet]
        public IActionResult AllCar()
        {
            var response =  _carService.GetCars();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("AllCar", response.Data);
            }

            return View("Error", $"{response.Description}");
        }*/

/*        [HttpGet]
        public async Task<ActionResult> GetCarSave(int id, bool isJson)
        {
            var response = await _carService.GetCar(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("Save", response.Data);
        }*/

/*        [HttpPost]
        public JsonResult GetTypes()
        {
            //var types = _carService.GetTypes();
            return Json(types.Data);
        }*/
    }
}
