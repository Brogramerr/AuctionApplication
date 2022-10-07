
using AuctionApplication.Context;
using AuctionApplication.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementations.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
        public async Task<Role> GetRoleByNameAsync(string name)
        {
             return _Context.Role
            .Include(x => x.UserRole)
            .Include(c => c.User)
            .Where(x => x.Name == name)
            .SingleOrDefault();
        }
    }
}