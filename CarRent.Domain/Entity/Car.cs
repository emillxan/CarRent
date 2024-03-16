using CarRent.Domain.Enum;

namespace CarRent.Domain.Entity;

public class Car
{
    public long Id { get; set; } // Уникальный идентификатор автомобиля
    public string? Brand { get; set; } // Марка автомобиля
    public string? Model { get; set; } // Модель автомобиля
    public decimal? RentalPricePerDay { get; set; } // Стоимость аренды за день
    public BodyType? BodyType { get; set; } // Тип кузова автомобиля
    public double? EngineVolume { get; set; } // Объем двигателя автомобиля
    public TransmissionType? TransmissionType { get; set; } // Тип трансмиссии автомобиля
    public string? Color { get; set; } // Цвет автомобиля
    public int? Mileage { get; set; } // Пробег автомобиля
    public int? MaxSpeed { get; set; } // Максимальная скорость автомобиля
    public int? YearOfProduction { get; set; } // Год производства автомобиля
    public FuelType? FuelType { get; set; } // Тип потребляемого топлива
    public bool? AvailableForRent { get; set; } // Доступен для аренды
    public bool? IsDeleted { get; set; }

    public List<CarPhoto> Photos { get; set; }
    public List<Rental> Rentals { get; set; }
}
