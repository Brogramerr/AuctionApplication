using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class AuctionResponseModel : BaseResponse
    {
        public AuctionDto  Data {get;set;}
    }
}