using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;

namespace AuctionApplication.Interface.Services
{
    public interface ICustomerService
    {
        Task<BaseResponse> Register(CreateCustomerRequestModel model);
        
    }
}