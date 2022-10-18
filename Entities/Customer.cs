using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Contracts;

namespace AuctionApplication.Entities
{
    public class Customer : AuditableEntity
    {
        public string Username {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string PhoneNumber { get; set; }
        public int UserId {get; set;}
        public User User {get;set;}
        public Wallet Wallet { get; set; }
        public List<Asset> Assets {get; set;}
        public List<Bidding> Biddings {get; set;}

    }
}