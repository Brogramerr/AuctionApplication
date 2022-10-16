using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class AuctionRepository : GenericRepository<Auction> , IAuctionRepository 
    {
        public AuctionRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
        public async Task<IList<Auction>> GetAuctionByDate(DateTime date)
        {
            return await _Context.Auctions
            .Include(auction => auction.Assets)
            .Where(x => x.OpeningDate == date).ToListAsync();
        }

       public async Task<Auction> GetAuctionById(int id)
        {
            return await _Context.Auctions
            .Where(x => x.Id == id)
            .Include(asset => asset.Assets).FirstOrDefaultAsync();
        }
    }
} 