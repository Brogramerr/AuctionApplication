using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.DTOs;
using AuctionApp.Interface.Services;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Interface.Repositories;

namespace AuctionApp.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IRoleRepository _roleRepository;
        public AdminService(IUserRepository userRepository, IAdminRepository adminRepository,IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _adminRepository = adminRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> AddAdmin(CreateAdminRequestModel model)
        {
            throw new NotImplementedException();
            var admin = await _adminRepository.GetAsync(admin => admin.User.Email == model.Email);
            if (admin != null)
            {
                return new BaseResponse()
                {
                    Message = "Admin Already Exist",
                    Success = false,
                };
            }
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
            };
            var adduser = await _userRepository.CreateAsync(user);
            var role = await _roleRepository.GetRoleByNameAsync("Admin");

            var userRole = new UserRole
            {
                UserId = adduser.Id,
                RoleId = role.Id,
            };
            adduser.UserRoles.Add(userRole);
            await _userRepository.UpdateAsync(adduser);

            var admins = new Admin 
            {
                UserId = adduser.Id,
                User = adduser,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                PhoneNumber = model.PhoneNumber,
                IsDeleted = false,
            };
            var addAdmin = await _adminRepository.CreateAsync(admins);
            return new BaseResponse
            {
                Message = "Admin Added Successfully",
                Success = true,
            };

        }

        public Task<BaseResponse> AddAdmin(CreateUserRequestModels model)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> DeleteAdmin(int Id)
        {
            var admin = await _adminRepository.GetAsync(admins => admins.IsDeleted == false && admins.Id == Id);
            if (admin == null )
            {
                return new BaseResponse
                {
                    Message = "Admin not found",
                    Success = false
                };
            }

            admin.IsDeleted = true;
            await _adminRepository.UpdateAsync(admin);
            return new BaseResponse
            {
                Message = "Administrator Successfully Deleted",
                Success = true
            };
        }

    }
}