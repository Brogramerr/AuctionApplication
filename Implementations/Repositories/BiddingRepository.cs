using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.Contracts;
namespace Implementations.Repositories
{
    public class BiddingRepository: GenericRepository<Bidding>, IBiddingRepository
    {
        
        public BiddingRepository(ApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<Bidding> GetBiddingByAuctionIdAsync(int id)
        {
            var bidding = await _Context.Biddings.Where(a => a.AssetId == id).Include(auction=> auction.Asset).Include(customer => customer.Customer).SingleOrDefaultAsync();
            return bidding;
        }
    

    }
}