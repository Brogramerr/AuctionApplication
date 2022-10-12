using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;

namespace AuctionApplication.Interface.Services
{
    public interface IAssetService
    {
        Task<BaseResponse> CreateAssetAsync(CreateAssetRequestModel model);
        Task<BaseResponse> ChangeAssetPriceAsync(int id,decimal StartingPrice);
        Task<BaseResponse> GetAssetsByAuctionDateAsync(DateTime auctionDate);
        Task<BaseResponse> DeleteAssetAsync(int id);
        Task<BaseResponse> GetAssetsToDisplayAsync(CreateAssetRequestModel model);

    }
}
