using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter first name")]
        [MaxLength(20, ErrorMessage = "The first name must be less than 20 characters long")]
        [MinLength(3, ErrorMessage = "The first name must be longer than 3 characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Enter second name")]
        [MaxLength(20, ErrorMessage = "The second name must be less than 20 characters long")]
        [MinLength(3, ErrorMessage = "The second name must be longer than 3 characters")]
        public string SecondName { get; set; }


        [Required(ErrorMessage = "Entar email")]
        [MaxLength(30, ErrorMessage = "eMail must be less than 35 characters long")]
        [MinLength(3, ErrorMessage = "eMail must be more than 3 characters long")]
        public string eMail { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        [MinLength(6, ErrorMessage = "Password must be longer than 6 characters")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Repeet Password")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string PasswordConfirm { get; set; }
    }
}
