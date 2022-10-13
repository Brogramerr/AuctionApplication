using AuctionApplication.Context;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(ApplicationContext Context)
        {
            _Context = Context;
        }

        
        public async Task<BaseResponse> ExistsByEmailAsync(string Email, string passWord)
        {
            var customer = await _Context.Customers.FirstOrDefaultAsync(c => c.Email == Email && c.Password == passWord);
            if (customer == null)
            {
                return new BaseResponse()
                {
                    Message = "Customer Not Found",
                    Success = false,
                };
            }
            return new BaseResponse()
            {
                Message = "Customer Found",
                Success = true,
            };
        }
        
        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _Context.Customers.Include(x => x.User).Include(x => x.Wallet).SingleOrDefaultAsync(c => c.Id == id);
            return customer;
        }
    }
}
