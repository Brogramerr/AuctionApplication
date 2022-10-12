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

        public async Task<Customer> AddAssetsForAuctionAsync(int id, int auctionId)
        {
            var customer = await _Context.Customers.Include(c => c.Assests).ThenInclude(a => a.Auction).FirstOrDefaultAsync(c => c.Id == id && c.Assests.Any(a => a.AuctionId == auctionId));
        }

        public async Task<Customer> ChangeAuctionAsync(int id, int auctionId)
        {
            var customer = await _Context.Customers.Include(c => c.Assests).ThenInclude(a => a.Auction).FirstOrDefaultAsync(c => c.Id == id && c.Assests.Any(a => a.AuctionId == auctionId));
        }
        
        public async Task<Customer> ExistsByEmailAsync(string Email, string password)
        {
            var customer = await _Context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.User.Email == Email && c.User.Password == password);
        }

        public async Task<Customer> GetAllBiddersAsync(int id)
        {
            var customer = await _Context.Customers.Include(x => x.Biddings).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetAssetsByDateTimeNowAsync(int id)
        {
            var customer = await _Context.Customers.Include(c => c.Assests).ThenInclude(a => a.Auction).FirstOrDefaultAsync(c => c.Id == id && c.Assests.Any(a => a.Auction.StartDate <= DateTime.Now && a.Auction.EndDate >= DateTime.Now));
        }

        public async Task<Customer> ChangeAssetsPriceAsync(int id, decimal price)
        {
            var customer = await _Context.Customers.Include(c => c.Assets).FirstOrDefaultAsync(c => c.Id == id && c.Assets.Price != price);
        }
        public async Task<Customer> ExistsByEmailAsync(string Email, string passWord)
        {
            var customer = await _Context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.Email == Email && c.Password == passWord);
            return customer;
        }
    }
}
