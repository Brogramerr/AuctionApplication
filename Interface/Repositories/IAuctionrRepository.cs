using AuctionApplication.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace AuctionApplication.Interface.Repositories
{
    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<Auction> GetAsync(int id);
        Task<IList<Auction>> GetAssetsByDate(DateTime date);
    }
}
