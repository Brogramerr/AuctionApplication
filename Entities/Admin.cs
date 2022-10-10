using System.Collections.Generic;
using AuctionApplication.Contracts;

namespace AuctionApplication.Entities.Identity;
public class Admin : AuditableEntity
{
    public string Username {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string PhoneNumber { get; set; }
    public int UserId {get; set;}
    public User User {get;set;}
   }