using System;

namespace AuctionApplication.DTOs.RequestModels
{

    public class CreateAuctionRequestModels
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}