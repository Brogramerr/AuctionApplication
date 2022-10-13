using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApplication.DTOs.RequestModels
{
    public class UpdateUserRoleRequestModel
    {
        public int UserId {get; set;}
        public string RoleName {get; set;}
    }
}