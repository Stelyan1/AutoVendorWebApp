using AutoVendor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var products = await dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.BrandModel)
                .AsNoTracking()
                .ToListAsync();
            
            return View("~/Views/Products/Index.cshtml", products);
        }
    }
}
