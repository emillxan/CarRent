using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DAL.Repositories
{
    public class UsersRepository : IBaseRepository<Users>
    {
        private readonly ApplicationDbContext _db;

        public UsersRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Users entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Users entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public IQueryable<Users> GetAll()
        {
            return _db.Users;
        }

        public async Task<Users> Update(Users entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
