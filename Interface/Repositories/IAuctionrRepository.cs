using AuctionApplication.Entities;
namespace AuctionApplication.Interface.Repositories
{
    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<IList<Auction>> GetAuctionByDate(DateTime date);
        Task<IList<Auction>> GetAllAuction();
        Task<Auction> GetAuctionById(int id);
    }
}
