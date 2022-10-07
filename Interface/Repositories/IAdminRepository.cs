namespace AuctionApplication.Interface.Repositories
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> CreateAdmin(Admin admin);
        Task<Admin> GetAdminById(int id);
    }
}