using AutoMapper;
using CarRent.Domain.Entity;
using CarRent.Domain.ViewModel.Car;
using CarRent.Domain.ViewModels.Car;

namespace CarRent.Domain.Mappings;

public class CarProfile : Profile
{
    public CarProfile()
    {
        // Маппинг сущности Car на CarViewModel
        CreateMap<Car, CarViewModel>();

        // Маппинг CarEditViewModel на Car и обратно
        CreateMap<CarEditViewModel, Car>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)); // Если требуется сохранить Id

        // Маппинг CarCreateViewModel на Car
        CreateMap<CarCreateViewModel, Car>();
    }
}
