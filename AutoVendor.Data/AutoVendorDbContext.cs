using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVendor.Data
{
    public class AutoVendorDbContext : DbContext
    {
        public AutoVendorDbContext() 
        {
        }

        public AutoVendorDbContext(DbContextOptions options) 
            : base (options)
        {

        }
    }
}
