using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Interface.Repositories;

namespace AuctionApp.Implementations.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public async Task<BaseResponse> AddRoleAsync(CreateRoleRequestmodel model)
        {
            var role = await _roleRepository.GetAsync(r=> r.Name == model.Name);
            if (role != null)
            {
                return new BaseResponse()
                {
                    Message = "Role Already Exist",
                    Success = false,
                };
            }
            var addrole = await _roleRepository.CreateAsync(role);
            return new BaseResponse
            {
                Message = "Role Created Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> GetAllRoleAsync(CreateRoleRequestmodel model)
        {
            
        }


    
    }
}