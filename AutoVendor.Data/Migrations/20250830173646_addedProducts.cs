using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoVendor.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppliableTo", "BelongToCategory", "Description", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("360a30d5-846d-4be0-b813-98851ec306d2"), new Guid("e78aed86-427b-4fc9-b2cd-a144b78c0de4"), new Guid("f6905fef-6e23-402b-9e9f-265862a45aea"), "The price is for 1 brake disc. For vehicles with M-performance brakes", "https://www.autopower.bg/images/%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%B5%D0%BD-%D0%B4%D0%B8%D1%81%D0%BA-BREMBO-PRIME-LINE-Composite-09C39413-BMW-3-Sedan-F30-F35-F80-340-i-xDrive-imagetabig-845520901700425-BREMBO.jpg", new Guid("003c6c86-80ef-4aa6-9e46-88c7ec45203e"), "Brake disc BREMBO PRIME LINE - Composite", 540m },
                    { new Guid("75dce1d9-e57f-4fae-b042-8f79f1322fa8"), new Guid("8a41e64e-a37c-4e3f-89de-254f845badcc"), new Guid("f6905fef-6e23-402b-9e9f-265862a45aea"), "The price is for 1 brake disc.", "https://www.autopower.bg/images/%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%B5%D0%BD-%D0%B4%D0%B8%D1%81%D0%BA-BREMBO-PRIME-LINE-Dual-Cast-09A94533-Mercedes-C-class-Saloon-w204-C-63-AMG-204.077-imagetabig-845520901699467-BREMBO.jpg", new Guid("003c6c86-80ef-4aa6-9e46-88c7ec45203e"), "Brake disc BREMBO PRIME LINE - Dual Cast", 1600m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("360a30d5-846d-4be0-b813-98851ec306d2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75dce1d9-e57f-4fae-b042-8f79f1322fa8"));

            
        
        }
    }
}
