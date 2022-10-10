using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
<<<<<<< HEAD
using Implementations.Repositories;
=======
>>>>>>> master
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
<<<<<<< HEAD
    public class AuctionRepository : BaseRepository<Auction> , IAuctionRepository 
=======
    public class AuctionRepository : GenericRepository<Auction> , IAuctionRepository 
>>>>>>> master
    {
        public AuctionRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
<<<<<<< HEAD
       public async Task<Auction> GetAsync(int id)
=======
        public async Task<Auction> GetAsync(int id)
>>>>>>> master
        {
            return await _Context.Auctions
            .Include(auction => auction.Customer)
            .Include(auction => auction.Biddings)
            .SingleOrDefaultAsync(x => x.Id == id);
        } 
    }
}