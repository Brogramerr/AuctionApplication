﻿using System;

namespace AuctionApp.DTOs.RequestModels
{
    public class ExtendAuctionExpiryDateRequestModel
    {
        
        public string AuctionId { get; set; }
        public DateTime AuctionExpiryDate { get; set; }
    }
}
