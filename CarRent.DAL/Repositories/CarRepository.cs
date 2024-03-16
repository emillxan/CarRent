using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
using CarRent.Domain.Extensions;
using CarRent.Domain.PagedLists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CarRent.DAL.Repositories
{
    public class CarRepository : IBaseRepository<Car>
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TResult?> GetFirstOrDefaultAsync<TResult>(Expression<Func<Car, TResult>> selector,
        Expression<Func<Car, bool>>? predicate = null,
        Func<IQueryable<Car>, IOrderedQueryable<Car>>? orderBy = null,
        Func<IQueryable<Car>, IIncludableQueryable<Car, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        bool ignoreAutoIncludes = false)
        {
            IQueryable<Car> query = _db.Car;

            if (disableTracking)
                query = query.AsNoTracking();

            if (include is not null)
                query = include(query);

            if (predicate is not null)
                query = query.Where(predicate);

            if (ignoreQueryFilters)
                query = query.IgnoreQueryFilters();

            if (ignoreAutoIncludes)
                query = query.IgnoreAutoIncludes();

            return orderBy is not null
                ? await orderBy(query).Select(selector).FirstOrDefaultAsync()
                : await query.Select(selector).FirstOrDefaultAsync();
        }

        public ValueTask<Car?> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _db.Car.FindAsync(keyValues, cancellationToken);

        public Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<Car, TResult>> selector,
        Expression<Func<Car, bool>>? predicate = null,
        Func<IQueryable<Car>, IOrderedQueryable<Car>>? orderBy = null,
        Func<IQueryable<Car>, IIncludableQueryable<Car, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        CancellationToken cancellationToken = default,
        bool ignoreQueryFilters = false,
        bool ignoreAutoIncludes = false)
        where TResult : class
        {
            IQueryable<Car> query = _db.Car;

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (ignoreQueryFilters)
                query = query.IgnoreQueryFilters();

            if (ignoreAutoIncludes)
                query = query.IgnoreAutoIncludes();

            return orderBy != null
                ? orderBy(query).Select(selector).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken)
                : query.Select(selector).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
        }

        public async Task<IList<TResult>> GetAllAsync<TResult>(
        Expression<Func<Car, TResult>> selector,
        Expression<Func<Car, bool>>? predicate = null,
        Func<IQueryable<Car>, IOrderedQueryable<Car>>? orderBy = null,
        Func<IQueryable<Car>, IIncludableQueryable<Car, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        bool ignoreAutoIncludes = false)
        {
            IQueryable<Car> query = _db.Car;

            if (disableTracking)
                query = query.AsNoTracking();

            if (include is not null)
                query = include(query);

            if (predicate is not null)
                query = query.Where(predicate);

            if (ignoreQueryFilters)
                query = query.IgnoreQueryFilters();

            if (ignoreAutoIncludes)
                query = query.IgnoreAutoIncludes();

            return orderBy is not null
                ? await orderBy(query).Select(selector).ToListAsync()
                : await query.Select(selector).ToListAsync();
        }

        public async Task<bool> InsertAsync(Car entity, CancellationToken cancellationToken = default)
        {
            await _db.Car.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Car> UpdateAsync(Car entity, CancellationToken cancellationToken = default)
        {
            _db.Car.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(Car entity, CancellationToken cancellationToken = default)
        {
            _db.Car.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }


        public async Task<int> CountAsync(
        Expression<Func<Car, bool>>? predicate = null,
        CancellationToken cancellationToken = default) =>
        predicate is null
            ? await _db.Car.CountAsync(cancellationToken)
            : await _db.Car.CountAsync(predicate, cancellationToken);

        public async Task<bool> Create(Car entity)
        {
            await _db.Car.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
            _db.Car.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public IQueryable<Car> GetAll()
        {
            return _db.Car;
        }

        public async Task<Car> Update(Car entity)
        {
            _db.Car.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
