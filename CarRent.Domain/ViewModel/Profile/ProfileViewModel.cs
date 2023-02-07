using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.ViewModel.Profile
{
    public class ProfileViewModel
    {
        public long Id { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string UserName { get; set; }

        public string eMail { get; set; }
    }
}
