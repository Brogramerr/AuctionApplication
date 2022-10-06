using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Entities;
using AuctionApp.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles{get;set;}
        public DbSet<UserRole> UserRoles{get;set;}
        public DbSet<Auction> Auctions{get;set;}
        public DbSet<Customer> Customers{get;set;}
        
        
        
    }
}
