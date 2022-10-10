using AuctionApplication.Entities;
using AuctionApplication.Entities.Identity;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace AuctionApplication.Interface.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string name);
    }
}