using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.Contracts;
namespace Implementations.Repositories
{
    public class BiddingRepository: BaseRepository<Bidding>, IBiddingRepository
    {
        
        public BiddingRepository(ApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<Bidding> GetBiddingByAuctionIdAsync(int id)
        {
            var bidding = await _Context.Biddings.Where(a => a.AuctionId == id).Include(auction=> auction.Auction).Include(customer => customer.Customer).SingleOrDefaultAsync();
            return bidding;
        }
      

    }
}