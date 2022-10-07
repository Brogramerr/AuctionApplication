<<<<<<< HEAD
﻿using System;

namespace AuctionApp.Contracts
=======
﻿namespace AuctionApplication.Contracts
>>>>>>> 825df9a3e599be0a1ebff0b3e3c1f651342e4395
{
    public interface ISoftDelete
    {
        DateTime? DeletedOn { get; set; }
        int? DeletedBy { get; set; }
        bool ? IsDeleted { get; set; }  
    }
}
