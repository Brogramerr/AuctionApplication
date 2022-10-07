<<<<<<< HEAD
﻿using System;

namespace AuctionApp.Contracts
=======
﻿namespace AuctionApplication.Contracts
>>>>>>> 825df9a3e599be0a1ebff0b3e3c1f651342e4395
{
    public interface IAuditableEntity
    {
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
