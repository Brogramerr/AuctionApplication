using System;

namespace AuctionApplication.DTOs.RequestModels
{

    public class UpdateCustomerRequestModels
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
       
    }
}