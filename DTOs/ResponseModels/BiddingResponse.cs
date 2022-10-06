using AuctionApplication.DTOs;

namespace AuctionApp.DTOs.ResponseModels
{
    public class BiddingResponse : BaseResponse
    {
        public BiddingDto  Data {get;set;}
    }
}