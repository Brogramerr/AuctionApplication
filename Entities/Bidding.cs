using AuctionApplication.Contracts;

namespace AuctionApplication.Entities;
public class Bidding : AuditableEntity
{
    public decimal Price {get; set;}
    public int CustomerId {get; set;}
    public Customer Customer {get; set;}
    public int AssetId {get; set;}
    public Asset Asset {get;}
    
}