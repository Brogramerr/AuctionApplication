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

        
    }
}