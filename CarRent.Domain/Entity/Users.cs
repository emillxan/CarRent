using CarRent.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.Entity
{
    public class Users
    {
        public long Id { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string eMail { get; set; }

        public Role Role { get; set; }

        public Profile Profile { get; set; }

        //public Basket Basket { get; set; }
    }
}
