using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Interface.Services;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Interface.Repositories;

namespace AuctionApp.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> AddAdmin(CreateUserRequestModels model)
        {
            throw new NotImplementedException();
            


        }

        public Task<BaseResponse> DeleteAdmin(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetAllAdmin()
        {
            throw new NotImplementedException();
        }
    }
}