using System;
using AuctionApplication.Entities;


namespace AuctionApplication.DTOs
{
    public class BiddingDto
    {
        public decimal Price { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get; set;}
        public string CustomerName {get;set;}

    }
}