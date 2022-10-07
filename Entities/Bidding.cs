using AuctionApplication.Contracts;

namespace AuctionApplication.Entities;
public class Bidding : AuditableEntity
{
    public decimal Price {get; set;}
    public int CustomerId {get; set;}
    public Customer Customer {get; set;}
    public int AuctionId {get; set;}
    public Auction Auction {get;}
    
}