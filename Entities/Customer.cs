using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuctionApplication.Entities.Identity;

namespace AuctionApplication.Entities
{
    public class Customer : User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Wallet Wallet { get; set; }
    }
}