<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using AuctionApp.Contracts;
using AuctionApp.Enum;
=======
﻿using AuctionApplication.Contracts;
using AuctionApplication.Enum;
>>>>>>> 825df9a3e599be0a1ebff0b3e3c1f651342e4395

namespace AuctionApplication.Entities
{
    public class Auction: AuditableEntity
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get;set; }
        public AuctionType AuctionType { get; set; }
        public int CustomerId {get;set;}
        public Customer Customer {get;set;}
        public bool IsApproved { get; set; }
        public List<Bidding> Biddings{get; set;} = new List<Bidding>();
    }
}
