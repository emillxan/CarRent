using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DAL.Repositories
{
    public class CarPhotosRepository : IBaseRepository<CarPhotos>
    {
        private readonly ApplicationDbContext _db;

        public CarPhotosRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(CarPhotos entity)
        {
            await _db.CarPhotos.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(CarPhotos entity)
        {
            _db.CarPhotos.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public IQueryable<CarPhotos> GetAll()
        {
            return _db.CarPhotos;
        }

        public async Task<CarPhotos> Update(CarPhotos entity)
        {
            _db.CarPhotos.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}