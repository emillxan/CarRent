namespace CarRent.Domain.Enum;

public enum RentalStatus
{
    Pending, // Ожидание подтверждения
    Active, // Активная аренда
    Completed, // Аренда завершена
    Canceled // Аренда отменена
}
