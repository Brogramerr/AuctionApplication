using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuctionApplication.Entities.Identity;

namespace AuctionApplication.Entities
{
    public class Customer : User
    {
        public int UserId {get;set;}
        public User User {get;set;}
        public List<Auction> Auctions {get;set;}
    }
}