using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.Entity
{
    public class CarPhotos
    {
        public long Id { get; set; }

        public string PhotoPath { get; set; }

        public long CarId { get; set; }
        
        public Car Car { get; set; }
    }
}
