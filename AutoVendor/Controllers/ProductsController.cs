using AutoVendor.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoVendor.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AutoVendorDbContext dbContext;
        public ProductsController(AutoVendorDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = this.dbContext.Products.ToList();
            return View("~/Views/Products/Index.cshtml", products);
        }
    }
}
