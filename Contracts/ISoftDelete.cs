﻿using System;

namespace AuctionApplication.Contracts
{
    public interface ISoftDelete
    {
        DateTime? DeletedOn { get; set; }
        int? DeletedBy { get; set; }
        bool ? IsDeleted { get; set; }  
    }
}
