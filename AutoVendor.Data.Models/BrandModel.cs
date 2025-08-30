using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVendor.Data.Models
{
    public class BrandModel
    {
        public BrandModel()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Name of the brand model car")]
        public string Name { get; set; } = null!;

        [Comment("Identifier of the brand model car")]
        public Guid Id { get; set; }

        [Comment("Given car model of a brand can be applied to many products")]
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
