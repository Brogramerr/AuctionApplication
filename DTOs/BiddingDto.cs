using AuctionApp.Entities;
using AuctionApp.Enum;

namespace AuctionApplication.DTOs
{
    public class BiddingDto
    {
        public decimal Price { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get; set;}

    }
}