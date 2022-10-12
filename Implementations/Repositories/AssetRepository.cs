using AuctionApp.Entities.Enums;
using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

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
            .Where(x => x.Auction.OpeningDate == date && x.IsDeleted == false)
            .ToListAsync();
        }
        

        public async Task<List<Asset>> GetAssetsToDisplayAsync()
        {
            var asset = await _Context.Assets.Where(c => 
            c.AssetStatus == AssetStatus.Auctioned &&
            c.Auction.OpeningDate <= DateTime.Now && c.Auction.IsDeleted == false &&
            c.Auction.OpeningDate.AddHours(c.Auction.Duration) >= DateTime.Now).ToListAsync();
            return asset;
        }
    }
}