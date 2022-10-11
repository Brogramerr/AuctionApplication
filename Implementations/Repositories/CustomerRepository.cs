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

        public async Task<Customer> AddAssetsForAuction(int id, int auctionId)
        {
            var customer = await _Context.Customers.Include(x => x.Assets).ThenInclude(x => x.Auction).FirstOrDefaultAsync(x => x.Id == id && x.Assets.Any(x => x.Auction.Id == auctionId));
            return customer;
        }

        public async Task<Customer> ChangeAssetsPriceAsync(int id, decimal price)
        {
            var customer = await _Context.Customers.Include(c => c.Assets).FirstOrDefaultAsync(c => c.Id == id && c.Wallet.Amount == price);
            return customer;
        }

        public async Task<Customer> ChangeAuctionAsync(int id, int auctionId)
        {
            var customer = await _Context.Customers.Include(x => x.Assets).ThenInclude(x => x.Auction).FirstOrDefaultAsync(x => x.Id == id && x.Assets.Any(x => x.Auction.Id == auctionId));
            return customer;
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            await _Context.Customers.AddAsync(customer);
            await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> ExistsByEmailAsync(string Email, string passWord)
        {
            var customer = await _Context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.Email == Email && c.Password == passWord);
            return customer;
        }


        public  async Task<Customer> GetCustomerById(int Id)
        {
            var Customer = await _Context.Customers.Include(x => x.UserRoles).ThenInclude(us => us.User).SingleOrDefaultAsync(x => x.Id == Id);
            return Customer;

        }
    }
}
