using AutoMapper;
using Client.Interfaces;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;

        public DashboardController(IApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            var watches = await _apiService.GetWatchListAsync();
            var watchList = watches.ToList();
            return View(watchList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateViewModel watch = new CreateViewModel();
            return PartialView("CreatePartial", watch);
        }

        public async Task<ActionResult<WatchViewModel>> AddProduct(CreateViewModel item)
        {
            await _apiService.CreateWatchAsync(item);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            await _apiService.DeleteWatchByIdAsync(itemId);
            return Json(new { success = true, message = "Item deleted successfully." });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int itemId)
        {
            var result = await _apiService.GetWatchByIdAsync(itemId);
            UpdateViewModel watchToBeUpdated = _mapper.Map<UpdateViewModel>(result);
            return PartialView("UpdatePartial", watchToBeUpdated);
        }

        public async Task<ActionResult<WatchViewModel>> UpdateProduct(UpdateViewModel item)
        {
            await _apiService.UpdateWatchAsync(item);
            return RedirectToAction("Index");
        }
    }
}
