using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IStoreRepository repository;

        public int PageSize = 4;


        public HomeController(
            IStoreRepository repo)
        {
            //_logger = logger;
            repository = repo;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((pageNumber -1) * PageSize)
                .Take(PageSize));
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
