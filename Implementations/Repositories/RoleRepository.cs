
using AuctionApplication.Context;
using AuctionApplication.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Entities;
using AuctionApplication.Entities;
using Microsoft.EntityFrameworkCore;
namespace AuctionApplication.Implementations.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
         public async Task<Role> GetRoleByUserId(int id)
        {
            var role = await _Context.UserRoles.Include(c => c.User).Include(x => x.Role).SingleOrDefaultAsync(x => x.Id == id);
            return role.Role;
        }

     
    }
}