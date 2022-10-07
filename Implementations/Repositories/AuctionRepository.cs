using AuctionApplication.Entities;

namespace AuctionApplication.Implementations.Repositories
{
    public class AuctionRepository : GenericRepository<Aution> , IAuctionRepository 
    {
        public AuctionRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
       public async Task<Auction> GetAsync(int id)
        {
            return await _Context.Set<T>().Include(auction => auction.Customer).ThenInclude(auction => auction.Bidding).SingleOrDefaultAsync(x => x.Id == id);
        } 
    }
}