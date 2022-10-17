using AuctionApplication.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace AuctionApplication.Interface.Repositories
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
       Task<List<Asset>> GetAssetsByAuctionDateAsync(DateTime AuctionDate);
       Task<List<Asset>> GetAssetsToDisplayAsync();
    }
}