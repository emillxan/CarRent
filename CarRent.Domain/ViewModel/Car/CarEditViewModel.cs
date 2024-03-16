namespace CarRent.Domain.ViewModel.Car;

public class CarEditViewModel
{
    public long Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string TypeCar { get; set; }
}
