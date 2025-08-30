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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.ImageUrl)
                   .IsRequired();

            builder.HasData(this.SeedCategories());
        }

        private IEnumerable<Category> SeedCategories()
        {
            IEnumerable<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Braking System",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%BD%D0%B0%20%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0.jpg"
                },

                new Category()
                {
                    Name = "Wheel Suspension",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%9E%D0%BA%D0%B0%D1%87%D0%B2%D0%B0%D0%BD%D0%B5%20%D0%BD%D0%B0%20%D0%BA%D0%BE%D0%BB%D0%B5%D0%BB%D0%B0%D1%82%D0%B0.jpg"
                },

                new Category()
                {
                    Name = "Steering System",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%9A%D0%BE%D1%80%D0%BC%D0%B8%D0%BB%D0%BD%D0%B0%20%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0.jpg"
                },

                new Category()
                {
                    Name = "Belt Drive",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%A0%D0%B5%D0%BC%D1%8A%D1%87%D0%BD%D0%BE%20%D0%B7%D0%B0%D0%B4%D0%B2%D0%B8%D0%B6%D0%B2%D0%B0%D0%BD%D0%B5.jpg"
                },

                new Category()
                {
                    Name = "Oils and liquids",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%9C%D0%B0%D1%81%D0%BB%D0%B0%20%D0%B8%20%D1%82%D0%B5%D1%87%D0%BD%D0%BE%D1%81%D1%82%D0%B8.jpg"
                },

                new Category()
                {
                    Name = "Filters",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%A4%D0%B8%D0%BB%D1%82%D1%80%D0%B8.jpg"
                }
            };
            return categories;
        }
    }
}
