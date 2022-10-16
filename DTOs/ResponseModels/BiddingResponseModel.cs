using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class BiddingResponseModel : BaseResponse
    {
        public BiddingDto Data { get; set; }
    }
}