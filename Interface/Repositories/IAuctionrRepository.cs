using AuctionApplication.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace AuctionApplication.Interface.Repositories
{
    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<IList<Auction>> GetAuctionByDate(DateTime date);
        Task<Auction> GetAuctionById(int id);
    }
}
