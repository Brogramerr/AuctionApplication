using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class AuctionResponse : BaseResponse
    {
        public AuctionDto  Data {get;set;}
    }
}