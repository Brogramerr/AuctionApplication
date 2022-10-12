using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository 
    {
        public UserRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
        
    }
}