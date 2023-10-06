using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext _context;
        readonly DbSet<T> table;
        public Repository(AppDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }


        public async Task<List<T>> AllAsync()
        {
            return await table.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> AllOrderByAsync(Expression<Func<T, int>> exp, bool AscOrDesc = true)
        {
            return AscOrDesc ? await table.AsNoTracking().OrderBy(exp).ToListAsync() : await table.AsNoTracking().OrderByDescending(exp).ToListAsync();
        }

        public async Task<List<T>> AllIncludeAsync<A>(Expression<Func<T, List<A>>> include, Expression<Func<T, int>> exp, bool AscOrDesc = true)
        {
            return AscOrDesc ? await table.AsNoTracking().Include(include).OrderBy(exp).ToListAsync() : await table.AsNoTracking().OrderByDescending(exp).ToListAsync();
        }

        public async Task<List<T>> AllIncludeAsync<A>(Expression<Func<T, A>> include, Expression<Func<T, int>> exp, bool AscOrDesc = true)
        {
            return AscOrDesc ? await table.AsNoTracking().Include(include).OrderBy(exp).ToListAsync() : await table.AsNoTracking().OrderByDescending(exp).ToListAsync();
        }

        public async Task<List<T>> AllFilterAsync(Expression<Func<T, bool>> exp, bool AsnoTracking = true)
        {
            return AsnoTracking ? await table.AsNoTracking().Where(exp).ToListAsync() : await table.Where(exp).ToListAsync();
        }


        public async Task<T> FindAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> exp, bool AsnoTracking = true)
        {
            return AsnoTracking ? await table.AsNoTracking().SingleOrDefaultAsync(exp) : await table.SingleOrDefaultAsync(exp);
        }

        public async Task CreateAsync(T entity)
        {
            await table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable GetQueryable()
        {
            return table.AsQueryable();
        }
    }
}
