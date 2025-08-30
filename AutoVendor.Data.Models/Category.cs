using Microsoft.EntityFrameworkCore;

namespace AutoVendor.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("Name of the category")]
        public string Name { get; set; } = null!;

        [Comment("Identifier of the category")]
        public Guid Id { get; set; }

        [Comment("Given category can have many products")]
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
