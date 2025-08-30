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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData(this.SeedBrands());
        }

        private IEnumerable<Brand> SeedBrands() 
        {
            IEnumerable<Brand> brands = new List<Brand>()
            {
                new Brand()
                {
                    Name = "Brembo"
                },

                new Brand()
                {
                    Name = "Valeo"
                },

                new Brand()
                {
                    Name = "ATE"
                },

                new Brand()
                {
                    Name = "Castrol"
                },

                new Brand()
                {
                    Name = "Lemforder"
                },

                new Brand()
                {
                    Name = "Monroe"
                }
            };
            return brands;
        }
    }
}
