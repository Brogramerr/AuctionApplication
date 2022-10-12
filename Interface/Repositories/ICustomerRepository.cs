using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
<<<<<<< HEAD
        Task<Customer> ExistsByEmailAsync(string Email, string passWord);
        Task<Customer> GetById(int id);
=======
        Task<User> ExistsByEmailAsync(string Email, string password);
        Task<Customer> ChangeAssetsPriceAsync(int id, decimal price);
        Task<Customer> GetAllBiddersAsync(int id);
        Task<Customer> RemoveAssetsAsync(int id);
        Task<Customer> GetAssetsByDateTimeNowAsync(int id);
        Task<Customer> ChangeAuctionAsync(int id, int auctionId);
        Task<Customer> AddAssetsForAuctionAsync(int id, int auctionId);
>>>>>>> 0ea5be8 (update)
    }
}

