using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomer(int id);
    }
}

