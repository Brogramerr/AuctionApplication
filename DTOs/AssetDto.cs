using System;
using AuctionApplication.Entities;

namespace AuctionApplication.DTOs
{
    public class AssetDto
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public bool IsOpened { get; set; }
        public int AutioneerId {get;set;}
        public Customer Auctioneer {get;set;}
        public int BuyerId {get;set;}
        public Customer Buyer {get;set;}
        public List<Bidding> Biddings{get; set;} = new List<Bidding>();
        public bool IsAuctioned {get; set;}
    }
}