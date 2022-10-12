using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;

namespace AuctionApplication.Implementations.Repositories
{
    public class AssetRepository : GenericRepository<Asset> , IAssetRepository
    {
        public AssetRepository(ApplicationContext Context)
        {
            _Context = Context;
        }

        
        public async Task<List<Asset>> GetAssetsByAuctionDateAsync(DateTime date)
        {
            return await _Context.Assets
            .Include(x => x.Auction)
            .Where(x => x.Auction.OpeningDate == date)
            .ToListAsync();
        }
        

        public Task<List<Asset>> GetAssetsToDisplayAsync()
        {
            throw new NotImplementedException();
        }
    }
}