using System;
using AuctionApplication.Entities;
using AuctionApplication.Enum;

namespace AuctionApplication.DTOs
{
    public class BiddingDto
    {
        public int Id {get; set;}
        public decimal Price { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get; set;}

    }
}