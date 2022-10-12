using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>
    {
        public WalletRepository(ApplicationContext Context)
        {
            _Context = Context;
        }    
    }
}