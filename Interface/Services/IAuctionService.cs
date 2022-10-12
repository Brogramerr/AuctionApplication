using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;

namespace AuctionApplication.Interface.Services
{
    public interface IAuctionService
    {
        Task<BaseResponse> ChangeAuctionOpeningDateAsync(int id, DateTime ExpiryDate);
        Task<BaseResponse> CreateAuctionAsync(CreateAuctionRequestModels model);
        Task<BaseResponse> ChangeAuctionDurationAsync(int id, int days);
    }
}