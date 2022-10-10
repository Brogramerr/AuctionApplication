using AuctionApplication.Entities;
using AuctionApplication.Entities.Identity;

namespace AuctionApplication.Interface.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> ExistsByEmailAsync(string Email, string Password);
       
    }
}