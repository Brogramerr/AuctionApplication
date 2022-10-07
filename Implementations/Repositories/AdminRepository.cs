namespace AuctionApplication.Implementations.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AuctionContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            var result = await _context.Admins.AddAsync(admin);
            return result;
        }

        public async Task<Admin> GetAdminById(int id)
        {
            var user =  await _context.Admins.Where(x => x.Id == admin.id && x.IsDeleted == false).Include(x => x.User).FirstOrDefaultAsync();
            return user;
        }
    }
}