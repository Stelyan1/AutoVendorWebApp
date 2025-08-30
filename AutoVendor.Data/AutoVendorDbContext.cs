using AutoVendor.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<BrandModel> BrandModels { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
