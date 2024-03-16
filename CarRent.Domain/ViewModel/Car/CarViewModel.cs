using CarRent.Domain.Enum;

namespace CarRent.Domain.ViewModels.Car;

public class CarViewModel
{
    public long Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string TypeCar { get; set; }
    public List<string> Photos { get; set; }

    public FuelType? FuelType { get; set; }
    public TransmissionType? TransmissionType { get; set; }
    public BodyType? BodyType { get; set; }
    public int? MaxSpeed { get; set; }
}
