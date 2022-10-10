using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
namespace AuctionApplication.Interface.Services
{
    public interface IAuctionService
    {
        Task<BaseResponse> ApproveAuction(int id);
        Task<BaseResponse> DisApproveAuction(int id);
        Task<BaseResponse> ExtendAuctionExpiryDate(int id, DateTime ExpiryDate);
        Task<BaseResponse> CreateAuction(CreateAuctionRequestModel model);
        Task<BaseResponse> DeleteAuctionAsync(int id);
        Task<BaseResponse> ChangeAuctionPriceAsync(int id, decimal price);
    }
}