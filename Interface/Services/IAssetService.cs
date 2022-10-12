using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;



namespace AuctionApplication.Interface.Services
{
    public interface IAssetService
    {
        Task<BaseResponse> ExtendAuctionExpiryDate(int id, DateTime ExpiryDate);
        Task<BaseResponse> CreateAssetAsync(CreateAssetRequestModel model);
        Task<BaseResponse> DeleteAssetAsync(int id);
        Task<BaseResponse> ChangeAuctionPriceAsync(int id, decimal price);
    }
}