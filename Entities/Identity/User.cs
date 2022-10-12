using System.Collections.Generic;
using AuctionApplication.Contracts;

namespace AuctionApplication.Entities.Identity;
public class User : AuditableEntity
{
    public string Email {get; set;}  
    public string Password { get; set; }
    public Customer Customer {get;set;}
    public Admin Admin {get; set;}
    public List<UserRole> UserRoles {get; set;} = new List<UserRole>();
}