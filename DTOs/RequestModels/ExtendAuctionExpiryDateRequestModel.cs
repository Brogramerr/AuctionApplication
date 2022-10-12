﻿using System;

﻿namespace AuctionApplication.DTOs.RequestModels
{
    public class ExtendAuctionExpiryDateRequestModel
    {
        public int AuctionId { get; set; }
        public int Duration { get; set; }
    }
}
