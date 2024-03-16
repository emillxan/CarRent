using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Domain.Entity;

public class CarPhoto
{
    public long Id { get; set; } // Уникальный идентификатор фотографии
    public string PhotoName { get; set; } // Название фотографии
    public bool IsDeleted { get; set; }

    public long CarId { get; set; } // Идентификатор автомобиля, к которому относится фотография
    public Car Car { get; set; }
}
