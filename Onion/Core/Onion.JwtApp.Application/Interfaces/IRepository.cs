using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {

        #region List
        Task<List<T>> AllIncludeAsync(Expression<Func<T, object>> include, Expression<Func<T, int>> exp, bool AscOrDesc = true);
        Task<List<T>> AllIncludeAsync(Expression<Func<T, object>> include1, Expression<Func<T, object>> include2, Expression<Func<T, int>> exp, bool AscOrDesc = true);
        Task<List<T>> AllFilterAsync(Expression<Func<T, bool>> exp, bool AsnoTracking = true);
        Task<List<T>> AllOrderByAsync(Expression<Func<T, int>> exp, bool AscOrDesc = true);
        Task<List<T>> AllAsync();
        #endregion

        #region Get T
        Task<T> FindAsync(int id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> exp, bool AsnoTracking = true);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, object>> include, Expression<Func<T, bool>> exp, bool AsnoTracking = true);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, object>> include1, Expression<Func<T, object>> include2, Expression<Func<T, bool>> exp, bool AsnoTracking = true);

        #endregion


        IQueryable GetQueryable();
        Task Remove(T entity);
        Task Update(T entity, T unchanged);
        Task CreateAsync(T entity);

    }
}
