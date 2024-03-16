using AutoMapper;
using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
using CarRent.Domain.Enum;
using CarRent.Domain.Extensions;
using CarRent.Domain.PagedLists;
using CarRent.Domain.Response;
using CarRent.Domain.ViewModels.Car;
using CarRent.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;


namespace CarRent.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<Car> _carRepository;
        private readonly IBaseRepository<CarPhoto> _carPhotosRepository;
        private readonly IMapper _mapper;

        public CarService(IBaseRepository<Car> carRepository,
            IBaseRepository<CarPhoto> carPhotosRepository,
            IMapper mapper)
        {
            _carRepository = carRepository;
            _carPhotosRepository = carPhotosRepository;
            _mapper = mapper;
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
                var img =  _carPhotosRepository.GetAll().ToList().Where(x => x.CarId == id);
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
                    Model = car.Model
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
            /*var baseResponse = new BaseResponse<Dictionary<long, string>>();
            try
            {
                var cars = await _carRepository.GetAll()
                    .Select(x => new CarViewModel()
                    {
                        Id = x.Id,
                        Model = x.Model,
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
            }*/
            return new BaseResponse<Dictionary<long, string>>()
            {
                StatusCode = StatusCode.InternalServerError
            };
        }
        public async Task<IBaseResponse<Car>> Create(CarViewModel model, IFormFile CarPhoto)
        {
            try
            {
                var car = new Car()
                {
                    Model = model.Model,
                };
                await _carRepository.Create(car);

/*                var CarPphoto = new CarPhoto() 
                { 
                    CarId = model.Id,
                    PhotoPath = CarPhoto.FileName
                };
                await _carPhotosRepository.Create(CarPphoto);

                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(CarPhoto.FileName);
                using(Stream stream = new FileStream("wwwroot/img/" + fileName, FileMode.Create))
                {
                    CarPhoto.CopyTo(stream);
                }*/

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
                var img = _carPhotosRepository.GetAll().ToList().Where(x => x.CarId == id);
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
                foreach(var item in img)
                {
                    await _carPhotosRepository.Delete(item);
                }

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




        public async Task<IBaseResponse<CarViewModel>> GetById(long id)
        {
            try
            {
                var car = await _carRepository.GetFirstOrDefaultAsync(
                    selector: car => car, 
                    predicate: car => car.Id == id
                    );
                //var img = _carPhotosRepository.GetAll().ToList().Where(x => x.CarId == id);

                if (car == null)
                {
                    return new BaseResponse<CarViewModel>()
                    {
                        Description = "Машина не найдена",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var carVm = _mapper.Map<CarViewModel>(car);

                return new BaseResponse<CarViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = carVm
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

        public async Task<IBaseResponse<IPagedList<CarViewModel>>> GetByPage(CarFilters carFilters, int pageIndex, int pageSize)
        {
            try
            {
                var carsPage = await _carRepository.GetPagedListAsync(
                    selector: car => car,
                    pageIndex: pageIndex,
                    pageSize: pageSize,
                    predicate: car =>
                        (string.IsNullOrEmpty(carFilters.Brand) || car.Brand == carFilters.Brand) /*&&
                        (string.IsNullOrEmpty(carFilters.Model) || car.Model == carFilters.Model) &&
                        (!carFilters.MinPrice.HasValue || car.RentalPricePerDay >= carFilters.MinPrice) &&
                        (!carFilters.MaxPrice.HasValue || car.RentalPricePerDay <= carFilters.MaxPrice) &&
                        (!carFilters.BodyType.HasValue || car.BodyType == carFilters.BodyType) &&
                        (!carFilters.MinEngineVolume.HasValue || car.EngineVolume >= carFilters.MinEngineVolume) &&
                        (!carFilters.MaxEngineVolume.HasValue || car.EngineVolume <= carFilters.MaxEngineVolume) &&
                        (!carFilters.TransmissionType.HasValue || car.TransmissionType == carFilters.TransmissionType) &&
                        (string.IsNullOrEmpty(carFilters.Color) || car.Color == carFilters.Color) &&
                        (!carFilters.MinMileage.HasValue || car.Mileage >= carFilters.MinMileage) &&
                        (!carFilters.MaxMileage.HasValue || car.Mileage <= carFilters.MaxMileage) &&
                        (!carFilters.MinYearOfProduction.HasValue || car.YearOfProduction >= carFilters.MinYearOfProduction) &&
                        (!carFilters.MaxYearOfProduction.HasValue || car.YearOfProduction <= carFilters.MaxYearOfProduction) &&
                        (!carFilters.FuelType.HasValue || car.FuelType == carFilters.FuelType) &&
                        (!carFilters.AvailableForRent.HasValue || car.AvailableForRent == carFilters.AvailableForRent)*/
                    );

                if (carsPage == null)
                {
                    return new BaseResponse<IPagedList<CarViewModel>>()
                    {
                        Description = "Машина не найдена",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var carVmList = _mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(carsPage.Items);
                var pagedCarVm = new PagedList<CarViewModel>(
                    carVmList.ToList(),
                    pageIndex,
                    pageSize,
                    carsPage.IndexFrom,
                    carsPage.TotalCount
                );

                return new BaseResponse<IPagedList<CarViewModel>>()
                {
                    StatusCode = StatusCode.OK,
                    Data = pagedCarVm
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IPagedList<CarViewModel>>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IPagedList<CarViewModel>>> GetByPage(int pageIndex, int pageSize)
        {
            try
            {
                var carsPage = await _carRepository.GetPagedListAsync(
                    selector: car => car,
                    pageIndex: pageIndex,
                    pageSize: pageSize
                    );

                if (carsPage == null)
                {
                    return new BaseResponse<IPagedList<CarViewModel>>()
                    {
                        Description = "Машина не найдена",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var carVmList = _mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(carsPage.Items);
                var pagedCarVm = new PagedList<CarViewModel>(
                    carVmList.ToList(),
                    pageIndex,
                    pageSize,
                    carsPage.IndexFrom,
                    carsPage.TotalCount
                );

                return new BaseResponse<IPagedList<CarViewModel>>()
                {
                    StatusCode = StatusCode.OK,
                    Data = pagedCarVm
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IPagedList<CarViewModel>>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Create(CarViewModel carViewModel)
        {
            try
            {
                var car = _mapper.Map<Car>(carViewModel);

                car.IsDeleted = false;

                var createdCar = await _carRepository.InsertAsync(car);

                return new BaseResponse<Car>
                {
                    StatusCode = StatusCode.OK,
                    Data = car,
                    Description = "Car created successfully."
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Failed to create car: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(long id, CarViewModel model)
        {
            try
            {
                var car = await _carRepository.GetFirstOrDefaultAsync(
                    selector: car => car,
                    predicate: car => car.Id == id
                    );
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.CarNotFound
                    };
                }


                car.Model = model.Model;


                await _carRepository.Update(car);


                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.OK,
                };
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

        public async Task<IBaseResponse<bool>> Delete(long id)
        {
            try
            {
                var car = await _carRepository.GetFirstOrDefaultAsync(
                    selector: car => car,
                    predicate: car => car.Id == id
                    );

                if (car == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.OK,
                        Description = $"Car with id {id} not found."
                    };
                }

                car.IsDeleted = true;

                await _carRepository.UpdateAsync(car);

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Description = "Car deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Failed to delete car: {ex.Message}"
                };
            }
        }
    }
}
