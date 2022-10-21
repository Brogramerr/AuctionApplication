using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class BiddingRepository : GenericRepository<Bidding>, IBiddingRepository
    {

        public BiddingRepository(ApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Bidding>> GetBiddingsByAssetIdAsync(int id)
        {
            var bidding = await _Context.Biddings.Where(a => a.AssetId == id).Include(a => a.Asset).Include(customer => customer.Customer).OrderByDescending(c => c.Price).ToListAsync();
            return bidding;
        }
        public decimal GetHighestBiddingPriceByAssetIdAsync(int id)
        {
            var bidding =  _Context.Biddings.Where(a => a.AssetId == id).Include(a => a.Asset).Include(customer => customer.Customer).OrderByDescending(x => x.Price).ToList();
            return bidding[0].Price;
        }

        public async Task<Bidding> GetHighestBidderAsync()
        {
            var bidder = await _Context.Biddings.Include(x => x.Customer).Include(x => x.Asset).OrderByDescending(x => x.Price).ToListAsync(); ;
            return bidder[0];
        }

        public async Task<Bidding> GetBiddingByCustomerId(int id)
        {
            return await _Context.Biddings
            .FirstOrDefaultAsync(c => c.CustomerId == id);
        }
    }
}