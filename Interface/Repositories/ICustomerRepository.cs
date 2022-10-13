using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> ExistsByEmailAsync(string Email, string passWord);
        Task<Customer> GetById(int id);
    }
}

