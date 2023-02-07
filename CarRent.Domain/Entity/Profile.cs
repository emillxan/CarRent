using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.Entity
{
    public class Profile
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public long UserId { get; set; }

        public Users User { get; set; }
    }
}
