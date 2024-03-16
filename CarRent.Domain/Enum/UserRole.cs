using System.ComponentModel.DataAnnotations;

namespace CarRent.Domain.Enum
{
    public enum UserRole
    {
        [Display(Name = "Админ")]
        Admin,
        [Display(Name = "Модератор")]
        Manager,
        [Display(Name = "Пользователь")]
        User,
        Guest
    }
}
