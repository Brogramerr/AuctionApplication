
using AuctionApplication.Context;
using AuctionApplication.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AuctionApplication.Interface.Repositories;
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
         public async Task<User> GetRoleByUserId(int id)
        {
            var user = await _Context.Users.Include(c => c.UserRoles).ThenInclude(c => c.User).SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }

     
    }
}