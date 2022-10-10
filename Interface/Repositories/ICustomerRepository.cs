using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<bool> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int Id);
    }
}
