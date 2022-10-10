using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
<<<<<<< HEAD
<<<<<<< HEAD
using Implementations.Repositories;
=======
>>>>>>> master
=======
>>>>>>> master
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class AuctionRepository : BaseRepository<Auction> , IAuctionRepository 
=======
    public class AuctionRepository : GenericRepository<Auction> , IAuctionRepository 
>>>>>>> master
=======
    public class AuctionRepository : GenericRepository<Auction> , IAuctionRepository 
>>>>>>> master
    {
        public AuctionRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
<<<<<<< HEAD
<<<<<<< HEAD
       public async Task<Auction> GetAsync(int id)
=======
        public async Task<Auction> GetAsync(int id)
>>>>>>> master
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