using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;

namespace AuctionApplication.Interface.Repositories
{
    public interface IRoleService
    {
        Task<BaseResponse> AddRoleAsync(CreateRoleRequestmodel model);
        Task<RolesResponse> GetAllRoleAsync();
        Task<BaseResponse> UpdateUserRole(UpdateUserRoleRequestModel model);
        Task<RoleResponseModel> GetRoleByUserId(int id);
    }
}