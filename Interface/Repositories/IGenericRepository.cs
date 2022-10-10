using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
<<<<<<< HEAD
namespace AuctionApplication.Interface.Repositories;
public interface IGenericRepository <T>{
        
=======
namespace AuctionApplication.Interface.Repositories

{
    public interface IGenericRepository<T>
    {

>>>>>>> master
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
<<<<<<< HEAD
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression); 
        void DeleteAsync(T entity);

        
       
}
=======
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        void DeleteAsync(T entity);



    }
}
>>>>>>> master
