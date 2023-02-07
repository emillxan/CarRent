using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DAL.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Profile entity)
        {
            await _dbContext.Profile.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> Delete(Profile entity)
        {
            _dbContext.Profile.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IQueryable<Profile> GetAll()
        {
            return _dbContext.Profile;
        }

        public async Task<Profile> Update(Profile entity)
        {
            _dbContext.Profile.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
