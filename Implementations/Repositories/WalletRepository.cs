using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
         public  async Task<Wallet> GetWalletAsync(int Id)
        {
            var wallet = await _Context.Wallets.Where(x => x.Id == Id).Include(x => x.Customer.Wallet).ThenInclude(customer => customer.Customer).SingleOrDefaultAsync();
            return wallet;

        }    
    }
}