using AuctionApp.Enum;

namespace AuctionApplicationlication.DTOs.RequestModels
{

    public class UpdateAuctionRequestModels
    {
        public int Id { get; set; }
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public AuctionType AuctionType { get; set; }
    }

}