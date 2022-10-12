using System.Linq.Expressions;
using System.Threading.Tasks;
using AuctionApplication.Entities;
namespace AuctionApplication.Interface.Repositories
{
    public interface IBiddingRepository : IGenericRepository<Bidding>
    {
        Task<IList<Bidding>> GetBiddingByAssetIdAsync(int id);
       
    }
}
