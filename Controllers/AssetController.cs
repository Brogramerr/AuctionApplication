using AuctionApplication.Context;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Implementation.Services;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AuctionApplication.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetService assetService;
        protected readonly IAssetRepository assetRepo;
        public AssetController(ApplicationContext context)
        {
            assetRepo = new AssetRepository(context);
            assetService = new AssetService(assetRepo);
        }



        public async Task<IActionResult> Create(CreateAssetRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var result = await assetService.CreateAssetAsync(model);
                if (result.Success == true)
                {
                    return StatusCode(201, "Asset successfully created");
                }
                return StatusCode(406, "Asset was not created");
            }
            return View();
        }
        public async Task<IActionResult> Add(int id)
        {
            if (HttpContext.Request.Method == "POST")
            {
                await assetService.AddAssetForAuctionAsync(id);

                return StatusCode(201, "Asset added successfully.");
            }
            return BadRequest();
        }


    }
}