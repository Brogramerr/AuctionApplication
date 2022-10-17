using AuctionApplication.DTOs;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Interface.Repositories;

namespace AuctionApplication.Implementations.Services
{
    public class RoleService : IRoleService
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
            var role = await _roleRepository.GetAsync(r => r.Name == model.Name);
            if (role != null)
            {
                return new BaseResponse()
                {
                    Message = "Role Already Exist",
                    Success = false,
                };
            }
            var newRole = new Role
            {
                Name = model.Name,
                Description = model.Description,
            };
            await _roleRepository.CreateAsync(newRole);
            return new BaseResponse
            {
                Message = "Role Created Successfully",
                Success = true,
            };
        }

        public async Task<RolesResponse> GetAllRoleAsync()
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
                Data = role.Select(x => new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList(),
                Message = "Roles Found Successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> UpdateUserRole(UpdateUserRoleRequestModel model)
        {
            var user = await _userRepository.GetAsync(u => u.Id == model.UserId);
            if (user == null)
            {
                return new BaseResponse
                {
                    Message = "User Not Found",
                    Success = false,
                };
            }
            var updateUserRole = user.UserRoles.Where(x => x.UserId == user.Id).ToList();
            var getRole = await _roleRepository.GetAsync(x => x.Name == model.RoleName);
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
