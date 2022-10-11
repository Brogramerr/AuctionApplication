using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<User> ExistsByEmailAsync(string Email, string password);
        Task<Customer> GetCustomerById(int Id);
    }
}
