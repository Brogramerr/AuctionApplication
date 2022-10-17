using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.DTOs;
using AuctionApp.DTOs.RequestModels;
using AuctionApp.DTOs.ResponseModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Interface.Repositories;

namespace AuctionApp.Implementations.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
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

        public async Task<RolesResponse> GetAllRoleAsync(CreateRoleRequestmodel model)
        { 
            var role = await _roleRepository.GetAllAsync();
            if (role == null)
            {
                 return new RolesResponse
                {
                    Message = "No Roles Found",
                    Success = false,
                };
            }
            return new RolesResponse
            {
                Data = role.Select(x=> new RoleDto{
                Name = x.Name,
                Description = x.Description,
                } ).ToList(),
                Message = "Roles Found Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> UpdateUserRole(UpdateUserRoleRequestModel model)
        {
            var user = await _userRepository.GetAsync(u=> u.Id == model.UserId);
            if (user == null)
            {
                return new BaseResponse
                {
                    Message = "User Not Found",
                    Success = false,
                };
            }
            var updateUserRole = user.UserRoles.Where(x=> x.UserId == user.Id).ToList();
            var getRole = await _roleRepository.GetRoleByNameAsync(model.RoleName);
            foreach (var item in updateUserRole)
            {
                item.RoleId = getRole.Id;
            }
            user.UserRoles = updateUserRole;
            await _userRepository.UpdateAsync(user);
            return new BaseResponse
            {
                Message = "User Role Updated Successfully",
                Success = true,
            };
        }
    }
}
