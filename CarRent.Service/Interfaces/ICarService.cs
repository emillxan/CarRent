using CarRent.Domain.Entity;
using CarRent.Domain.Response;
using CarRent.Domain.ViewModels;
using CarRent.Domain.ViewModels.Car;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Service.Interfaces
{
    public interface ICarService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();

        IBaseResponse<List<Car>> GetCars();

        Task<IBaseResponse<CarViewModel>> GetCar(long id);

        Task<BaseResponse<Dictionary<long, string>>> GetCar(string term);

        Task<IBaseResponse<Car>> Create(CarViewModel car, IFormFile CarPhoto);

        Task<IBaseResponse<bool>> DeleteCar(long id);

        Task<IBaseResponse<Car>> Edit(long id, CarViewModel model);
    }
}
