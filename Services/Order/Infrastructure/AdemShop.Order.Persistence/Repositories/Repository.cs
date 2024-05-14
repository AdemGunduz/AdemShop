using AdemShop.Order.Application.Interfaces;
using Domain.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace AdemShop.Order.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AdmContext _admcontext;

        public Repository(AdmContext admcontext)
        {
            _admcontext = admcontext;
        }

        public async Task CreateAsync(T entity)
        {
           _admcontext.Set<T>().Add(entity);
            await _admcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
           _admcontext.Set<T>().Remove(entity);
            await _admcontext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _admcontext.Set<T>().ToListAsync();   
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _admcontext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetIdAsync(Guid id)
        {
            return await _admcontext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
           _admcontext.Set<T>().Update(entity);
            await _admcontext.SaveChangesAsync();
        }
    }
}
