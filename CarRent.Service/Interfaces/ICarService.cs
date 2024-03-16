using CarRent.Domain.Entity;
using CarRent.Domain.PagedLists;
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
        //BaseResponse<Dictionary<int, string>> GetTypes();

        //IBaseResponse<List<Car>> GetCars();

        //Task<BaseResponse<Dictionary<long, string>>> GetCar(string term);
        Task<IBaseResponse<CarViewModel>> GetById(long id);
        Task<IBaseResponse<IPagedList<CarViewModel>>> GetByPage(CarFilters carFilters, int pageIndex, int pageSize);
        Task<IBaseResponse<IPagedList<CarViewModel>>> GetByPage(int pageIndex, int pageSize);
        Task<IBaseResponse<Car>> Create(CarViewModel car);
        Task<IBaseResponse<bool>> Delete(long id);
        Task<IBaseResponse<Car>> Edit(long id, CarViewModel model);
    }
}
