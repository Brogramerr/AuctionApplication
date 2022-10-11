using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> ExistsByEmailAsync(string Email, string passWord);
        Task<Customer> ChangeAssetsPriceAsync(int id, decimal price);
        Task<Customer> ChangeAuctionAsync(int id, int auctionId);
        Task<Customer> AddAssetsForAuction(int id, int auctionId);
    }
}

