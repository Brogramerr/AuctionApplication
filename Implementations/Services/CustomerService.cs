using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;

using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Entities;

namespace AuctionApplication.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Register(CreateCustomerRequestModel model)
        {
            var customer = await _customerRepository.GetAsync(customer => customer.User.Email == model.Email);
            if(customer != null)
            {
                return new BaseResponse()
                {
                    Message = "Email Already Exist",
                    Success = false,
                };
            }

            var custm  = new Customer()
            {
                User = new User()
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password,
                    CreatedBy = model.UserId,
                    LastModifiedBy = model.UserId,
                    IsDeleted = false,
                }
            };
            var custom = await _customerRepository.CreateAsync(custm);
            if(custom == null)
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

        public async Task<CustomerResponse> GetById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if(customer == null)
            {
                return new CustomerResponse()
                {
                    Message = "Customer not found",
                    Success = false,
                };
            }

            return new CustomerResponse()
            {
                Message = "Customer Retrived Successfully",
                Success = false,
                Data = new CustomerDto()
                {
                        FirstName = customer.User.FirstName,
                        LastName = customer.User.LastName,
                        Username = customer.User.Username,
                        Email = customer.User.Email,
                        PhoneNumber = customer.User.PhoneNumber,
                }
            };
        }
    }
}