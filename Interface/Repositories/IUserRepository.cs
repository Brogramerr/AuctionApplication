using AuctionApplication.Entities;
namespace AuctionApplication.Interface.Repositories
{
    public class IUserRepository : IGenericRepository<User>
    {
        Task<User> ExistsByEmailAsync(string Email, string Password);
        Task<User> GetUserByIdRoleAsync(int id, string role);
       
    }
}