using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;

namespace AuctionApplication.Interface.Services
{
    public interface IAssetService
    {
        Task<BaseResponse> CreateAssetAsync(CreateAssetRequestModel model);
        Task<BaseResponse> ChangeAssetPriceAsync(int id, decimal Price);
        Task<AssetsResponseModel> GetAssetsByAuctionDateAsync(DateTime Date);
        Task<BaseResponse> DeleteAssetAsync(int id);
        Task<AssetsResponseModel> GetAssetsToDisplayAsync();
        Task<BaseResponseModel> ChangAssetStatusToSold(int id);
        Task<AssetsResponseModel> AddAssetForAuctionAsync();
        Task<AssetsResponseModel> AddAssetsForAuctionAsync();

    }
}
