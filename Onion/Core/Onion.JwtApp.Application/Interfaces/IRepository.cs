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
        IQueryable GetQueryable();
        Task Remove(T entity);
        Task Update(T entity, T unchanged);
        Task CreateAsync(T entity);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> exp, bool AsnoTracking = true);
        Task<List<T>> AllIncludeAsync<A>(Expression<Func<T, List<A>>> include, Expression<Func<T, int>> exp, bool AscOrDesc = true);
        Task<List<T>> AllIncludeAsync<A>(Expression<Func<T, A>> include, Expression<Func<T, int>> exp, bool AscOrDesc = true);
        Task<T> FindAsync(int id);
        Task<List<T>> AllFilterAsync(Expression<Func<T, bool>> exp, bool AsnoTracking = true);
        Task<List<T>> AllOrderByAsync(Expression<Func<T, int>> exp, bool AscOrDesc = true);
        Task<List<T>> AllAsync();
    }
}
