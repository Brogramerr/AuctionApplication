using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
namespace AuctionApplication.Interface.Services
{
    public interface IAuctionService
    {
        Task<BaseResponse> ApproveAuction(int id);
        Task<BaseResponse> DisApproveAuction(int id);
        Task<BaseResponse> ExtendAuctionExpiryDate(int id, DateTime ExpiryDate);
     
    }
}