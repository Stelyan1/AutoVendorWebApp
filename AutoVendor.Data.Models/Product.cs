using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVendor.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Identifier of the product")]
        public Guid Id { get; set; }

        [Comment("Name of the Product")]
        public string Name { get; set; } = null!;

        [Comment("Description about the product")]
        public string Description { get; set; } = null!;

        [Comment("Price of the product")]
        public decimal Price { get; set; }

        [Comment("Product image")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Category of the Product")]
        public Guid BelongToCategory { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Comment("Manufacturer of the product")]
        public Guid Manufacturer { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        [Comment("Can be applied to many car models")]
        public Guid AppliableTo { get; set; }
        public virtual BrandModel BrandModel { get; set; } = null!;

    }
}
