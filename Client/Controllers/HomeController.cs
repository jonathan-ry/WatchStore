﻿//using Client.Models;
using Client.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var watches = await _apiService.GetWatchListAsync();
            var watchList = watches.ToList();
            return View(watchList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}