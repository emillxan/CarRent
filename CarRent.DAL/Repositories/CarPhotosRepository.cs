using CarRent.DAL.Interfaces;
using CarRent.Domain.Entity;
using CarRent.Domain.Extensions;
using CarRent.Domain.PagedLists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DAL.Repositories
{
    public class CarPhotosRepository : IBaseRepository<CarPhoto>
    {
        private readonly ApplicationDbContext _db;

        public CarPhotosRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> CountAsync(
                Expression<Func<CarPhoto, bool>>? predicate = null,
                CancellationToken cancellationToken = default) =>
                predicate is null
                    ? await _db.CarPhoto.CountAsync(cancellationToken)
                    : await _db.CarPhoto.CountAsync(predicate, cancellationToken);

        public async Task<bool> Create(CarPhoto entity)
        {
            await _db.CarPhoto.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(CarPhoto entity)
        {
            _db.CarPhoto.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(CarPhoto entity, CancellationToken cancellationToken = default)
        {
            _db.CarPhoto.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public ValueTask<CarPhoto?> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _db.CarPhoto.FindAsync(keyValues, cancellationToken);

        public IQueryable<CarPhoto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TResult>> GetAllAsync<TResult>(Expression<Func<CarPhoto, TResult>> selector, Expression<Func<CarPhoto, bool>>? predicate = null, Func<IQueryable<CarPhoto>, IOrderedQueryable<CarPhoto>>? orderBy = null, Func<IQueryable<CarPhoto>, IIncludableQueryable<CarPhoto, object>>? include = null, bool disableTracking = true, bool ignoreQueryFilters = false, bool ignoreAutoIncludes = false)
        {
            IQueryable<CarPhoto> query = _db.CarPhoto;

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

        public async Task<TResult?> GetFirstOrDefaultAsync<TResult>(Expression<Func<CarPhoto, TResult>> selector, Expression<Func<CarPhoto, bool>>? predicate = null, Func<IQueryable<CarPhoto>, IOrderedQueryable<CarPhoto>>? orderBy = null, Func<IQueryable<CarPhoto>, IIncludableQueryable<CarPhoto, object>>? include = null, bool disableTracking = true, bool ignoreQueryFilters = false, bool ignoreAutoIncludes = false)
        {
            IQueryable<CarPhoto> query = _db.CarPhoto;

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

        public Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<CarPhoto, TResult>> selector, Expression<Func<CarPhoto, bool>>? predicate = null, Func<IQueryable<CarPhoto>, IOrderedQueryable<CarPhoto>>? orderBy = null, Func<IQueryable<CarPhoto>, IIncludableQueryable<CarPhoto, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true, CancellationToken cancellationToken = default, bool ignoreQueryFilters = false, bool ignoreAutoIncludes = false) where TResult : class
        {
            IQueryable<CarPhoto> query = _db.CarPhoto;

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

        public async Task<bool> InsertAsync(CarPhoto entity, CancellationToken cancellationToken = default)
        {
            await _db.CarPhoto.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<CarPhoto> Update(CarPhoto entity)
        {
            _db.CarPhoto.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<CarPhoto?> UpdateAsync(CarPhoto entity, CancellationToken cancellationToken = default)
        {
            _db.CarPhoto.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}