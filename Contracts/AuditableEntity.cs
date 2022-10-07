<<<<<<< HEAD
﻿using System;

namespace AuctionApp.Contracts
=======
﻿namespace AuctionApplication.Contracts
>>>>>>> 825df9a3e599be0a1ebff0b3e3c1f651342e4395
{
    public class AuditableEntity : BaseEntity, IAuditableEntity, ISoftDelete
    {
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get ; set; }
        public int LastModifiedBy { get ; set ; }
        public DateTime? LastModifiedOn { get ; set ; }
        public DateTime? DeletedOn { get ; set; }
        public int? DeletedBy { get ; set ; }
        public bool? IsDeleted { get ; set ; }
        DateTime? IAuditableEntity.CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime? IAuditableEntity.LastModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
