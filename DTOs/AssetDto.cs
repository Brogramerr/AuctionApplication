using System;
using AuctionApplication.Entities.Enums;
using AuctionApplication.Entities;

namespace AuctionApplication.DTOs
{
    public class AssetDto
    {
        public int AssetId { get; set; }
        public decimal Price { get; set; }
        public decimal? SoldPrice { get; set; }
        public string AssetName { get; set; }
         public string ImageUrl { get; set; }
        public bool AuctionPriceIsOpened { get; set; }
        public string Auctioneer { get; set; }
        public string Buyer {get;set;}
        public List<BiddingDto> Biddings{get; set;} = new List<BiddingDto>();
        public AssetStatus AssetStatus {get; set;}
    }
} 