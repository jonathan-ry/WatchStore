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


        public async Task<IActionResult> Index(string sortOrder = "newest")
        {
            var response = new DashboardViewModel();
            var watches = await _apiService.GetWatchListAsync();
            switch(sortOrder)
            {
                case "newest":
                    var watchList = watches.OrderByDescending(w => w.Id).ToList();
                    response.Watches.AddRange(watchList);
                    response.SortValue = sortOrder;
                    return View(response);
                case "name":
                     watchList = watches.OrderBy(w => w.Name).ToList();
                    response.Watches.AddRange(watchList);
                    response.SortValue = sortOrder;
                    return View(response);
                case "priceHigh":
                     watchList = watches.OrderByDescending(w => w.Price).ToList();
                    response.Watches.AddRange(watchList);
                    response.SortValue = sortOrder;
                    return View(response);
                case "priceLow":
                     watchList = watches.OrderBy(w => w.Price).ToList();
                    response.Watches.AddRange(watchList);
                    response.SortValue = sortOrder;
                    return View(response);
                default:
                    watchList = watches.ToList();
                    response.Watches.AddRange(watchList);
                    response.SortValue = sortOrder;
                    return View(response);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateViewModel watch = new();
            return View("Create", watch);
        }

        public async Task<ActionResult<WatchViewModel>> AddProduct(CreateViewModel item)
        {
            TempData["IsCreate"] = true;
            if (ModelState.IsValid) 
            {
                await _apiService.CreateWatchAsync(item);
                TempData["IsSuccess"] = true;
                return RedirectToAction("Index");
            }

            TempData["IsSuccess"] = false;
            return PartialView("CreatePartial", item);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            await _apiService.DeleteWatchByIdAsync(itemId);
            return Json(new { success = true, message = "Item deleted successfully." });
        }

        public async Task<IActionResult> Update(int itemId)
        {
            var result = await _apiService.GetWatchByIdAsync(itemId);
            UpdateViewModel watchToBeUpdated = _mapper.Map<UpdateViewModel>(result);
            return View(watchToBeUpdated);
        }

        public async Task<ActionResult<WatchViewModel>> UpdateProduct(UpdateViewModel item)
        {
            await _apiService.UpdateWatchAsync(item);
            return RedirectToAction("Index");
        }
    }
}
