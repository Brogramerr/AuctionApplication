using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class AssetsResponseModel : BaseResponse
    {
        public List<AssetDto> Data { get; set; } = new List<AssetDto>();
    }
    public class AssetResponseModel : BaseResponse
    {
        public AssetDto Data { get; set; } 
    }
}