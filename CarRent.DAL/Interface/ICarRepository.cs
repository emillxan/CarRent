using CarRent.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
