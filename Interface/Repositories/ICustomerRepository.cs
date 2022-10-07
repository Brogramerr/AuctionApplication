using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int Id);
    }
}
