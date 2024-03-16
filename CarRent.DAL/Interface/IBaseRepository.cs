using CarRent.Domain.PagedLists;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<TResult?> GetFirstOrDefaultAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        bool ignoreAutoIncludes = false);

        ValueTask<T?> FindAsync(object[] keyValues, CancellationToken cancellationToken);

        Task<IPagedList<TResult>> GetPagedListAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        CancellationToken cancellationToken = default,
        bool ignoreQueryFilters = false,
        bool ignoreAutoIncludes = false) where TResult : class;

        Task<IList<TResult>> GetAllAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        bool ignoreAutoIncludes = false);

        Task<bool> InsertAsync(T entity, CancellationToken cancellationToken = default);

        Task<T?> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);

        Task<bool> Create(T entity);
        IQueryable<T> GetAll();
        Task<bool> Delete(T entity);
        Task<T> Update(T entity);
    }
}
