using System.Diagnostics;
using AutoVendor.Data;
using AutoVendor.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoVendor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AutoVendorDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, AutoVendorDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var products = this.dbContext.Products.ToList();
            return View("~/Views/Home/Index.cshtml", products);
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
