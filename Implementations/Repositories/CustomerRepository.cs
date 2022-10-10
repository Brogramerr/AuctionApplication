using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
<<<<<<< HEAD
using Implementations.Repositories;
=======
>>>>>>> master
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
<<<<<<< HEAD
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
=======
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
>>>>>>> master
    {

        public CustomerRepository(ApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            await _Context.Customers.AddAsync(customer);
            await _Context.SaveChangesAsync();
            return true;
        }

        public  async Task<Customer> GetCustomerById(int Id)
        {
            var Customer = await _Context.Customers.Include(x => x.UserRoles).ThenInclude(us => us.User).SingleOrDefaultAsync(x => x.Id == Id);
            return Customer;

        }
    }
}
