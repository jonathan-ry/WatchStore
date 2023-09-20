using AutoMapper;
using Client.Interfaces;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ProductController : Controller
    {
        private readonly IApiService _apiService;

        public ProductController(IApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var watches = await _apiService.GetWatchListAsync();
            var watchList = watches.ToList();
            return View(watchList);
        }

        public async Task<IActionResult> Detail(int productId)
        {
            var watch = await _apiService.GetWatchByIdAsync(productId);
            return View(watch);
        }

    }
}
