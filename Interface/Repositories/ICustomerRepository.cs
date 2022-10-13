using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;

namespace AuctionApplication.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<BaseResponse> ExistsByEmailAsync(string Email, string passWord);
        Task<BaseResponse> GetById(int id);
    }
}

