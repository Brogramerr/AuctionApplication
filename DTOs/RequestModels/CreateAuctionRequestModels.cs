using AuctionApplication.Enum;

namespace AuctionApplication.DTOs.RequestModels
{

    public class CreateAuctionRequestModels
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public AuctionType AuctionType { get; set; }
        public int CustomerId {get;set;}
        
    }
}