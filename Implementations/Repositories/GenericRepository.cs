using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Context;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.Contracts;

<<<<<<< HEAD
namespace Implementations.Repositories
{ 
    public class BaseRepository<T>: IGenericRepository<T> where T : class, new()
=======
namespace AuctionApplication.Implementations.Repositories
{ 
    public class GenericRepository<T>: IGenericRepository<T> where T : class, new()
>>>>>>> master
    {
        protected ApplicationContext _Context;
        public async Task<T> CreateAsync(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _Context.Set<T>().Update(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }
        public void DeleteAsync(T entity)
        {
            _Context.Set<T>().Remove(entity);
            _Context.SaveChanges();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _Context.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _Context.Set<T>().Where(expression).ToListAsync();
        }




    }
}