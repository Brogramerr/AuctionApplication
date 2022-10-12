
using System;

namespace AuctionApplication.DTOs.RequestModels
{

    public class UpdateBiddingRequestModels
    {
        public decimal Price { get; set; }
       public int CustomerId { get; set; }
    }
}