using Client.Interfaces;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IApiService _apiService;

        public DashboardController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {

            var watches = await _apiService.GetWatchListAsync();
            var watchList = watches.ToList();
            return View(watchList);
        }

        //public async Task<IActionResult> DeleteItem(WatchViewModel watch)
        //{

        //}
    }
}
