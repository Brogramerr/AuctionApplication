using AuctionApplication.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
<<<<<<< HEAD
namespace AuctionApplication.Interface.Repositories;
public interface IAuctionRepository : IGenericRepository<Auction>
{
        Task<Auction> GetAsync(int id);
        
        
        

        
       
}
=======
namespace AuctionApplication.Interface.Repositories
{
    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<Auction> GetAsync(int id);
    }
}
>>>>>>> master
