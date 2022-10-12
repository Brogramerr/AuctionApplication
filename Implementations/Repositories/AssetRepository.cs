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
    }
}