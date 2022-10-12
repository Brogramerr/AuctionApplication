using AuctionApplication.Context;
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

        public async Task<Customer> ExistsByEmailAsync(string Email, string passWord)
        {
            var customer = await _Context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.Email == Email && c.Password == passWord);
            return customer;
        }
    }
}
