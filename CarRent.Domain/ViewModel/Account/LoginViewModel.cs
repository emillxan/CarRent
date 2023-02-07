using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRent.Domain.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter eMail")]
        [MaxLength(35, ErrorMessage = "Mail must be less than 35 characters long")]
        [MinLength(3, ErrorMessage = "Mail must be more than 3 characters long")]
        public string eMail { get; set; }


        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
