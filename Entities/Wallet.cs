using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Contracts;

namespace AuctionApplication.Entities
{
    public class Wallet : AuditableEntity
    {
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}