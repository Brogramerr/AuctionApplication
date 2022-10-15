using AuctionApplication.DTOs;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;
using AuctionApplication.Entities.Identity;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;

namespace AuctionApplication.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> Register(CreateCustomerRequestModel model)
        {
            var customer = await _customerRepository.GetAsync(customer => customer.User.Email == model.Email);
            if (customer != null)
            {
                return new BaseResponse()
                {
                    Message = "Email Already Exist",
                    Success = false,
                };
            }
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
            };
            var adduser = await _userRepository.CreateAsync(user);
            var custm = new Customer()
            {

                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            
            var custom = await _customerRepository.CreateAsync(custm);
            if (custom == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Register Customer",
                    Success = false,
                };
            }
            else
            {

                return new BaseResponse()
                {
                    Message = "Successfully Registered",
                    Success = true,
                };
            }
        }

        public async Task<CustomerResponseModel> GetById(int id)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer == null)
            {
                return new CustomerResponseModel
                {
                    Message = "Customer not found",
                    Success = false,
                };
            }

            return new CustomerResponseModel
            {
                Message = "Customer Retrived Successfully",
                Success = true,
                Data = new CustomerDto
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Username = customer.Username,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                }
            };
        }
        public async Task<BaseResponse> UpdateCustomer(UpdateCustomerRequestModels updatedCustomer)
        {
            var customer = await _customerRepository.GetCustomer(updatedCustomer.CustomerId);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "Customer Not Found",
                    Success = false,
                };
            }
            customer.FirstName = updatedCustomer.FirstName ?? customer.FirstName;
            customer.LastName = updatedCustomer.LastName ?? customer.LastName;
            customer.PhoneNumber = updatedCustomer.PhoneNumber ?? customer.PhoneNumber;
            customer.Username = updatedCustomer.Username ?? customer.Username;
            customer.User.Email = updatedCustomer.Email ?? customer.User.Email;
            await _customerRepository.UpdateAsync(customer);
            return new BaseResponse
            {
                Message = "Customer updated successfully",
                Success = true,
            };
        }
    }
}