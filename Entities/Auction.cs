using AuctionApp.Contracts;
using AuctionApp.Enum;

namespace AuctionApp.Entities
{
    public class Auction: AuditableEntity
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDare { get;set; }
        public AuctionType AuctionType { get; set; }
        public int CustomerId {get;set;}
        public Customer Customer {get;set;}
    }
}
