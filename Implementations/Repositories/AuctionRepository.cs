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
        public async Task<Auction> GetAsync(int id)
        {
            return await _Context.Auctions
            .Include(auction => auction.Assets)
            .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
} 