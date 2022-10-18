using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApplication.DTOs;
using AuctionApplication.Interface.Services;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Interface.Repositories;

namespace AuctionApplication.Implementations.Services
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
            var admin = await _adminRepository.GetAsync(a => a.User.Email == model.Email);
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
            var role = await _roleRepository.GetAsync(x=> x.Name.Equals("Admin"));
            if(role == null)
            {
                return new BaseResponse{
                    Message = "Role not found",
                    Success = false 
                };
            }

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


        public async Task<AdminsResponseModel> GetAllAdmin()
        {
            var admins = await _adminRepository.GetAllAdminsAsync();
            return new AdminsResponseModel
            {
                Data = admins.Select(x => new AdminDto
                {
                    Id = x.Id,
                    UserName = x.Username,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                }).ToList()
            };
        }
    }
}