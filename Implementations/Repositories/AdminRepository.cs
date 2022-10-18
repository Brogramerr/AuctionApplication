using AuctionApplication.Context;
using AuctionApplication.Entities;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Implementations.Repositories
{
    public class AdminRepository : GenericRepository<Admin> , IAdminRepository 
    {
        public AdminRepository(ApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Admin>> GetAllAdminsAsync()
        {
            return await _Context.Admins
            .Include(admin => admin.User).Where(x => x.IsDeleted == false)
            .ToListAsync();
        }
    }
} 