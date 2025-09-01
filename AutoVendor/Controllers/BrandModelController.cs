using AutoVendor.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoVendor.Controllers
{
    public class BrandModelController : Controller
    {
        private readonly AutoVendorDbContext dbContext;
        public BrandModelController(AutoVendorDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var brandModels = this.dbContext.BrandModels.ToList();
            return View("~/Views/BrandModel/Index.cshtml", brandModels);
        }
    }
}
