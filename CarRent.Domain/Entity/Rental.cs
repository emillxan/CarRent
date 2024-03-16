using CarRent.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Domain.Entity;

public class Rental
{
    public long Id { get; set; } // Уникальный идентификатор аренды
    public long CarId { get; set; } // Идентификатор автомобиля, который арендован
    public long UserId { get; set; } // Идентификатор пользователя, который арендовал машину
    public bool IsDeleted { get; set; }

    public DateTime RentStartDate { get; set; } // Дата и время начала аренды
    public DateTime RentEndDate { get; set; } // Дата и время окончания аренды

    public decimal RentalCost { get; set; } // Стоимость аренды
    public RentalStatus Status { get; set; } // Статус аренды

    public Car Car { get; set; }
    public User User { get; set; }
}
