using System;


namespace AuctionApplication.DTOs
{
    public class AuctionDto
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get;set; }
    

    }
}