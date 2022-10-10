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
        public async Task<User> ExistsByEmailAsync(string email, string password)
        {
            var user = await _Context.Users.Include(user => user.UserRoles).ThenInclude( x => x.Role).FirstOrDefaultAsync(x => x.Email == email && x.Password == password && x.IsDeleted == false);
            return user;
        }

        public async Task<User> GetUserByRoleName(int id, string role)
        {
            var result = await _Context.Users.Include(user => user.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == id && x.UserRoles.Any(y => y.Role.Name == role));
            return result;
        }
    }
}