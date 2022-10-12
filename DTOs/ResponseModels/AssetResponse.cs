using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class AssetResponse : BaseResponse
    {
        public AssetDto  Data {get;set;}
        public List<Assets>Dto Data {get; set; }
    }
}