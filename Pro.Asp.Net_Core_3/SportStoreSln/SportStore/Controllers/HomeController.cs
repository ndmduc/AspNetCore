using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportStore.Models;
using SportStore.Models.ViewModels;

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

        public ViewResult Index(string category, int pageNumber = 1)
        {
            //return View(repository.Products
            //    .OrderBy(p => p.ProductID)
            //    .Skip((pageNumber -1) * PageSize)
            //    .Take(PageSize));
            return View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => p.Category == category || category == null)
                    .OrderBy(p => p.ProductID)
                    .Skip((pageNumber - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() 
                        : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            }); 
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
