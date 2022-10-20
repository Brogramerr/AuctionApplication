using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class AuctionsResponseModel : BaseResponse
    {
        public List<AuctionDto> Data { get; set; } = new List<AuctionDto>();
    }
    public class AuctionResponseModel : BaseResponse
    {
        public AuctionDto  Data {get;set;}
    }
}