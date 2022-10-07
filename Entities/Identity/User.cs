<<<<<<< HEAD
using System.Collections.Generic;
using AuctionApp.Contracts;
=======
using AuctionApplication.Contracts;
>>>>>>> 825df9a3e599be0a1ebff0b3e3c1f651342e4395

namespace AuctionApplication.Entities.Identity;
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