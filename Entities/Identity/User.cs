using System.Collections.Generic;
using AuctionApp.Contracts;

namespace AuctionApp.Entities.Identity;
public class User : BaseEntity 
{
    public string Username {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}  
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public Customer Customer {get;set;}
    public List<UserRole> UserRoles {get; set;} = new List<UserRole>();
}