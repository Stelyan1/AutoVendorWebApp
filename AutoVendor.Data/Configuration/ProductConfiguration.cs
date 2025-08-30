using AutoVendor.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVendor.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Brand)
                   .WithMany(m => m.Products)
                   .HasForeignKey(p => p.Manufacturer);

            builder.HasOne(p => p.BrandModel)
                   .WithMany(bm => bm.Products)
                   .HasForeignKey(p => p.AppliableTo);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.BelongToCategory);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .IsRequired();

            builder.Property(p => p.ImageUrl)
                   .IsRequired();

           builder.HasData(SeedProducts());
        }

        private IEnumerable<Product> SeedProducts()
        {
            IEnumerable<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Brake disc BREMBO PRIME LINE - Composite",
                    Description = "The price is for 1 brake disc. For vehicles with M-performance brakes",
                    Price = 540,
                    ImageUrl = "https://www.autopower.bg/images/%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%B5%D0%BD-%D0%B4%D0%B8%D1%81%D0%BA-BREMBO-PRIME-LINE-Composite-09C39413-BMW-3-Sedan-F30-F35-F80-340-i-xDrive-imagetabig-845520901700425-BREMBO.jpg",
                    Manufacturer = new Guid("003c6c86-80ef-4aa6-9e46-88c7ec45203e"),
                    BelongToCategory = new Guid("f6905fef-6e23-402b-9e9f-265862a45aea"),
                    AppliableTo = new Guid("E78AED86-427B-4FC9-B2CD-A144B78C0DE4")
                },

                new Product()
                {
                    Name = "Brake disc BREMBO PRIME LINE - Dual Cast",
                    Description = "The price is for 1 brake disc.",
                    Price = 1600,
                    ImageUrl = "https://www.autopower.bg/images/%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%B5%D0%BD-%D0%B4%D0%B8%D1%81%D0%BA-BREMBO-PRIME-LINE-Dual-Cast-09A94533-Mercedes-C-class-Saloon-w204-C-63-AMG-204.077-imagetabig-845520901699467-BREMBO.jpg",
                    Manufacturer = new Guid("003c6c86-80ef-4aa6-9e46-88c7ec45203e"),
                    BelongToCategory = new Guid("f6905fef-6e23-402b-9e9f-265862a45aea"),
                    AppliableTo = new Guid("8A41E64E-A37C-4E3F-89DE-254F845BADCC")
                }
            };
            return products;
        }
    }
}
