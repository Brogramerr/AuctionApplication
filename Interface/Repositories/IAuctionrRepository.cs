using AuctionApplication.Entities;
namespace AuctionApplication.Interface.Repositories
{
    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<IList<Auction>> GetAssetsByDate(DateTime date);
    }
}
