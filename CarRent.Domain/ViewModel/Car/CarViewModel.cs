using CarRent.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.ViewModels.Car
{
    public class CarViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Speed { get; set; }

        public int PiecesOfLuggage { get; set; }

        public int Doors { get; set; }

        public bool AutomaticTransmission { get; set; }

        public int MaxPassenger { get; set; }

        public string TypeCar { get; set; }
    }
}
