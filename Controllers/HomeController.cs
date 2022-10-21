using AuctionApplication.Interface.Services;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AuctionApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAssetService _assetService;

        public HomeController(ILogger<HomeController> logger,IAssetService assetService)
        {
            _logger = logger;
            _assetService = assetService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _assetService.GetAssetsToDisplayAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}