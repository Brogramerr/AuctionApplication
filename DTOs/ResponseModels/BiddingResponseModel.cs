using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class BiddingResponseModel : BaseResponse
    {
        public List<BiddingDto> Data { get; set; } = new List<BiddingDto>();
    }
}