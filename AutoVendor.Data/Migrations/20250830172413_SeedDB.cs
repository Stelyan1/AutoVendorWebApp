using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoVendor.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the brand model car"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Name of the brand model car"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the car"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year of the model"),
                    Fuel = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, comment: "Fuel type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of brand"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the brand")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the category"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the category"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the given category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the product"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Name of the Product"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description about the product"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Product image"),
                    BelongToCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Category of the Product"),
                    Manufacturer = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Manufacturer of the product"),
                    AppliableTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Can be applied to many car models")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_BrandModels_AppliableTo",
                        column: x => x.AppliableTo,
                        principalTable: "BrandModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_Brands_Manufacturer",
                        column: x => x.Manufacturer,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_BelongToCategory",
                        column: x => x.BelongToCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BrandModels",
                columns: new[] { "Id", "Fuel", "ImageUrl", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("5730d314-db00-44ce-9679-762ba4224d0a"), "Petrol", "https://images.hgmsites.net/hug/2015-mercedes-benz-cls-class_100552115_h.jpg", "Mercedes-Benz CLS 550", 2016 },
                    { new Guid("8a41e64e-a37c-4e3f-89de-254f845badcc"), "Petrol", "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/images/11q4/424156/2012-mercedes-benz-c63-amg-coupe-black-series-photo-429266-s-original.jpg", "Mercedes-Benz C63", 2012 },
                    { new Guid("d53e1ae1-d74d-4730-aa13-7bac65bbae00"), "Petrol", "https://urotuning.photos/image/lf9x07sa.jpeg", "BMW G30 540i", 2018 },
                    { new Guid("e78aed86-427b-4fc9-b2cd-a144b78c0de4"), "Petrol", "https://curvaconcepts.com/wp-content/uploads/silver-f30-bmw-340i-c300-4.jpg", "BMW F30 340i", 2016 }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("003c6c86-80ef-4aa6-9e46-88c7ec45203e"), "Brembo" },
                    { new Guid("17f94596-1034-4dff-9f0e-0017e6f0cfd4"), "Monroe" },
                    { new Guid("38a64e1c-9abf-43dc-9fdb-7e5fe7caf2d7"), "ATE" },
                    { new Guid("7a2fdf0a-cbdb-4bc0-8578-ffbe68250a3e"), "Valeo" },
                    { new Guid("8b5df958-dc1a-4bf6-af44-af8d9c894e43"), "Castrol" },
                    { new Guid("f522beba-9c4a-401d-9ba0-009a1788c629"), "Lemforder" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("21f5d9a3-acb6-4ab3-b9b8-d8a81606d611"), "https://www.autopower.bg/images/categories/%D0%9A%D0%BE%D1%80%D0%BC%D0%B8%D0%BB%D0%BD%D0%B0%20%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0.jpg", "Steering System" },
                    { new Guid("90e98b71-8bd8-4847-abf5-26ffc22cdd52"), "https://www.autopower.bg/images/categories/%D0%9C%D0%B0%D1%81%D0%BB%D0%B0%20%D0%B8%20%D1%82%D0%B5%D1%87%D0%BD%D0%BE%D1%81%D1%82%D0%B8.jpg", "Oils and liquids" },
                    { new Guid("a9ec2dee-05a2-479e-a242-2fd166ee62c3"), "https://www.autopower.bg/images/categories/%D0%9E%D0%BA%D0%B0%D1%87%D0%B2%D0%B0%D0%BD%D0%B5%20%D0%BD%D0%B0%20%D0%BA%D0%BE%D0%BB%D0%B5%D0%BB%D0%B0%D1%82%D0%B0.jpg", "Wheel Suspension" },
                    { new Guid("aafbcf17-8eef-47c7-b992-34e8007c9f90"), "https://www.autopower.bg/images/categories/%D0%A0%D0%B5%D0%BC%D1%8A%D1%87%D0%BD%D0%BE%20%D0%B7%D0%B0%D0%B4%D0%B2%D0%B8%D0%B6%D0%B2%D0%B0%D0%BD%D0%B5.jpg", "Belt Drive" },
                    { new Guid("c9efcea4-ceae-4128-9533-2efa52ade047"), "https://www.autopower.bg/images/categories/%D0%A4%D0%B8%D0%BB%D1%82%D1%80%D0%B8.jpg", "Filters" },
                    { new Guid("f6905fef-6e23-402b-9e9f-265862a45aea"), "https://www.autopower.bg/images/categories/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%BD%D0%B0%20%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0.jpg", "Braking System" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AppliableTo",
                table: "Products",
                column: "AppliableTo");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BelongToCategory",
                table: "Products",
                column: "BelongToCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Manufacturer",
                table: "Products",
                column: "Manufacturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "BrandModels");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
