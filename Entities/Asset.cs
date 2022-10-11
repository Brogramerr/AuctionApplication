using System;
using System.Collections.Generic;
using AuctionApplication.Contracts;


namespace AuctionApplication.Entities
{
    public class Asset: AuditableEntity
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public bool IsOpened { get; set; }
        public int AutioneerId {get;set;}
        public Auction Auction {get;set;}
        public Customer Auctioneer {get;set;}
        public int BuyerId {get;set;}
        public Customer Buyer {get;set;}
        public List<Bidding> Biddings{get; set;} = new List<Bidding>();
        public bool IsAuctioned {get; set;}
        
    }
}
