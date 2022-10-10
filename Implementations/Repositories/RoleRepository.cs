
using AuctionApplication.Context;
using AuctionApplication.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

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
             return await  _Context.Roles.Where(x => x.Name == name).SingleOrDefaultAsync();
        }
    }
}