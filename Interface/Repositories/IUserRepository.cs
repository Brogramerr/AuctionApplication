using AuctionApplication.Entities;
using AuctionApplication.Entities.Identity;

namespace AuctionApplication.Interface.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> ExistsByEmailAsync(string Email, string Password);
        Task<User> GetUserByRoleName(int id, string role);

    }
}