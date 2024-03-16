using CarRent.Domain.Enum;

namespace CarRent.Domain.Entity;

public class User
{
    public long Id { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public bool IsDeleted { get; set; }

    public List<Rental> Rentals { get; set; }
}
