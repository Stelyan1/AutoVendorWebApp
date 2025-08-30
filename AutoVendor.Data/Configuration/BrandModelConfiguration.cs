using AutoVendor.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AutoVendor.Data.Configuration
{
    public class BrandModelConfiguration : IEntityTypeConfiguration<BrandModel>
    {
        public void Configure(EntityTypeBuilder<BrandModel> builder)
        {
            builder.HasKey(bm => bm.Id);

            builder.Property(bm => bm.Name)
                   .IsRequired()
                   .HasMaxLength(70);

            builder.Property(bm => bm.ImageUrl)
                   .IsRequired();

            builder.Property(bm => bm.Year)
                   .IsRequired();

            builder.Property(bm => bm.Fuel)
                .IsRequired()
                .HasMaxLength(6);

            builder.HasData(this.SeedBrandModels());
        }

        private IEnumerable<BrandModel> SeedBrandModels() 
        {
            IEnumerable<BrandModel> brandModels = new List<BrandModel>()
            {
                new BrandModel()
                {
                    Name = "BMW F30 340i",
                    Year = 2016,
                    Fuel = "Petrol",
                    ImageUrl = "https://curvaconcepts.com/wp-content/uploads/silver-f30-bmw-340i-c300-4.jpg"
                },

                new BrandModel()
                {
                    Name = "Mercedes-Benz C63",
                    Year = 2012,
                    Fuel = "Petrol",
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/images/11q4/424156/2012-mercedes-benz-c63-amg-coupe-black-series-photo-429266-s-original.jpg"
                },

                new BrandModel()
                {
                    Name = "BMW G30 540i",
                    Year = 2018,
                    Fuel = "Petrol",
                    ImageUrl = "https://urotuning.photos/image/lf9x07sa.jpeg"
                },

                new BrandModel()
                {
                    Name = "Mercedes-Benz CLS 550",
                    Year = 2016,
                    Fuel = "Petrol",
                    ImageUrl = "https://images.hgmsites.net/hug/2015-mercedes-benz-cls-class_100552115_h.jpg"
                }
            };
            return brandModels;
        }
    }
}
