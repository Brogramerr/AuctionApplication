
namespace AuctionApplication.DTOs.RequestModels
{

    public class CreateBiddingRequestModels
    {
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public int AssestId { get; set; }
    }
}