using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
using CarRent.Domain.Enum;
using CarRent.Domain.Extensions;
using CarRent.Domain.Response;
using CarRent.Domain.ViewModels.Car;
using CarRent.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRent.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<Car> _carRepository;

        public CarService(IBaseRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeCar[])Enum.GetValues(typeof(TypeCar)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CarViewModel>> GetCar(long id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<CarViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var data = new CarViewModel()
                {
                    Name = car.Name,
                    Model = car.Model,
                    Description = car.Description,
                    Speed = car.Speed,
                    TypeCar = car.TypeCar.GetDisplayName(),
                    Price = car.Price,
                    PiecesOfLuggage = car.PiecesOfLuggage,
                    AutomaticTransmission = car.AutomaticTransmission,
                    Doors = car.Doors,
                    MaxPassenger = car.MaxPassenger
                };

                return new BaseResponse<CarViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Dictionary<long, string>>> GetCar(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<long, string>>();
            try
            {
                var cars = await _carRepository.GetAll()
                    .Select(x => new CarViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Model = x.Model,
                        Description = x.Description,
                        Speed = x.Speed,
                        TypeCar = x.TypeCar.GetDisplayName(),
                        Price = x.Price,
                        PiecesOfLuggage = x.PiecesOfLuggage,
                        AutomaticTransmission = x.AutomaticTransmission,
                        Doors = x.Doors,
                        MaxPassenger = x.MaxPassenger
                    })
                    .Where(x => EF.Functions.Like(x.Name, $"%{term}%"))
                    .ToDictionaryAsync(x => x.Id, t => t.Name);

                baseResponse.Data = cars;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<long, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Create(CarViewModel model, byte[] imageData)
        {
            try
            {
                var car = new Car()
                {
                    Name = model.Name,
                    Model = model.Model,
                    Description = model.Description,
                    Speed = model.Speed,
                    TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar),
                    Price = model.Price,
                    PiecesOfLuggage = model.PiecesOfLuggage,
                    AutomaticTransmission = model.AutomaticTransmission,
                    Doors = model.Doors,
                    MaxPassenger = model.MaxPassenger
                };
                await _carRepository.Create(car);

                return new BaseResponse<Car>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(long id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.CarNotFound,
                        Data = false
                    };
                }

                await _carRepository.Delete(car);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(long id, CarViewModel model)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.CarNotFound
                    };
                }

/*                car.Description = model.Description;
                car.Model = model.Model;
                car.Price = model.Price;
                car.Speed = model.Speed;
                car.DateCreate = DateTime.ParseExact(model.DateCreate, "yyyyMMdd HH:mm", null);
                car.Name = model.Name;
*/
                car.Name = car.Name;
                car.Model = car.Model;
                car.Description = car.Description;
                car.Speed = car.Speed;
                //car.TypeCar = car.TypeCar.GetDisplayName();
                car.Price = car.Price;
                car.PiecesOfLuggage = car.PiecesOfLuggage;
                car.AutomaticTransmission = car.AutomaticTransmission;
                car.Doors = car.Doors;
                car.MaxPassenger = car.MaxPassenger;

                await _carRepository.Update(car);


                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.OK,
                };
                // TypeCar
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
                var cars = _carRepository.GetAll().ToList();
                if (!cars.Any())
                {
                    return new BaseResponse<List<Car>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }



    }
}
