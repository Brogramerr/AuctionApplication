using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;

namespace AuctionApplication.Interface.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> AddAdmin(CreateAdminRequestModel model);
        Task<BaseResponse> DeleteAdmin(int Id);
        Task<AdminsResponseModel> GetAllAdmin();
    }
}