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

        [Comment("Name of the Product")]
        public string Name { get; set; } = null!;

        [Comment("Identifier of the product")]
        public Guid Id { get; set; }

        [Comment("Description about the product")]
        public string Description { get; set; } = null!;

        [Comment("Based on the product this can be used as additional info")]
        public string MoreInfo1 { get; set; } = string.Empty;

        [Comment("Based on the product this can be used as additional info")]
        public string MoreInfo2 { get; set; } = string.Empty;

        [Comment("Based on the product this can be used as additional info")]
        public string MoreInfo3 { get; set; } = string.Empty;

        [Comment("Based on the product this can be used as additional info")]
        public string MoreInfo4 { get; set; } = string.Empty;

        [Comment("Based on the product this can be used as additional info")]
        public string MoreInfo5 { get; set; } = string.Empty;

        [Comment("Based on the product this can be used as additional info")]
        public string MoreInfo6 { get; set; } = string.Empty;

        [Comment("Category of the Product")]
        public Guid BelongToCategory { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Comment("Manufacturer of the product")]
        public Guid Manufacturer { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        [Comment("Can be applied to many car models")]
        public virtual ICollection<BrandModel> BrandModels { get; set; } = new HashSet<BrandModel>();

    }
}
