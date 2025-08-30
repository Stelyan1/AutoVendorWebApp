using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVendor.Data.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Name of the brand")]
        public string Name { get; set; } = null!;

        [Comment("Identifier of brand")]
        public Guid Id { get; set; }

        [Comment("One brand can have many products")]
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
