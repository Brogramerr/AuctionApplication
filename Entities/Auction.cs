using System;
using System.Collections.Generic;
using AuctionApplication.Contracts;

namespace AuctionApplication.Entities
{
    public class Auction : AuditableEntity
    {
        public DateTime OpeningDate { get; set; }
        public List<Asset> Assets { get; set; } = new List<Asset>();
        public int Duration { get; set; }

    }
}
