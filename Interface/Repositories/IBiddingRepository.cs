using System.Linq.Expressions;
using System.Threading.Tasks;
using AuctionApplication.Entities;
namespace AuctionApplication.Interface.Repositories
{
    public interface IBiddingRepository : IGenericRepository<Bidding>
    {
        Task<Bidding> GetBiddingByAuctionIdAsync(int id);
        Task<Bidding> GetHighestBidderAsync(int id);

    }
}
