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
        Task<BaseResponse> ChangAssetStatusToSold(int id);
        Task<BaseResponse> ChangeAssetStatusToAuctioned(int id);
        Task<BaseResponse> AddAssetForAuctionAsync(int id);
        Task<IList<BaseResponse>> AddAssetsForAuctionAsync(HashSet<int> ids);
        Task<AssetResponseModel> GetAssetsById(int id);

    }
}
