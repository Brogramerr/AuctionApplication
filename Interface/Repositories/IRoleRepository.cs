using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;
using AuctionApplication.Entities.Identity;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace AuctionApplication.Interface.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetRoleByUserId(int id);
    }
}