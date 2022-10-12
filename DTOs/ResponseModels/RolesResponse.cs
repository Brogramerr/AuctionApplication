using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApplication.DTOs.ResponseModels;

namespace AuctionApp.DTOs.ResponseModels
{
    public class RolesResponse : BaseResponse
    {
        public List<RoleDto> Data {get;set;} = new List<RoleDto>();
    } 
}