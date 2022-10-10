using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class BiddingResponse : BaseResponse
    {
        public BiddingDto  Data {get;set;}
    }
}