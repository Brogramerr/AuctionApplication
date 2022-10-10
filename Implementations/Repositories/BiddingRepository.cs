using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class BiddingRepository: GenericRepository<Bidding>, IBiddingRepository
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
        public async Task<List<Bidding>> GetAllBiddings()
        {
            return await _Context.Biddings
            .Include(x => x.Customer)
            .Include(c => c.Auction)
            .OrderBy(c => c.Price).ToListAsync();
        }

        public async Task<Bidding> GetHighestBidderAsync(int id)
        {
           var bids = await GetAllBiddings();
           
            return bids[0];
        }
    }
}