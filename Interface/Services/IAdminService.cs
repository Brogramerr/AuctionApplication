using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;

namespace AuctionApp.Interface.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> AddAdmin(CreateUserRequestModels model);
        Task<BaseResponse> DeleteAdmin(int Id);
        
    }
}