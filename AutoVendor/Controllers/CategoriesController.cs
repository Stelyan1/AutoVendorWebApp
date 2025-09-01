using AutoVendor.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoVendor.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AutoVendorDbContext dbContext;
        public CategoriesController(AutoVendorDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = this.dbContext.Categories.ToList();
            return View("~/Views/Categories/Index.cshtml", categories);
        }
    }
}
