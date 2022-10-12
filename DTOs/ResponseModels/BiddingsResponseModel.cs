namespace AuctionApplication.DTOs.ResponseModels
{
    public class BiddingsResponseModel : BaseResponse
    {
       public List<BiddingDto> Bidding { get; set; } = new List<BiddingDto>();
    }
}