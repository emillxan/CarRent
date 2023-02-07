using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRent.Domain.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Enter eMail")]
        public string eMail { get; set; }


        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(5, ErrorMessage = "Password must be greater than or equal to 6 characters")]
        public string NewPassword { get; set; }
    }
}
