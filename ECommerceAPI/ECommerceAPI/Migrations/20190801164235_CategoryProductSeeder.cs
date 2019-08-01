using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceAPI.Migrations
{
    public partial class CategoryProductSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "PC" },
                    { 2L, "Laptop" },
                    { 3L, "Tablet" },
                    { 4L, "Video game console" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Description", "ImageUrl", "Name", "OutOfStock", "Quantity" },
                values: new object[] { 1L, 4L, 399.99000000000001, "Fourth generation of the Playstation console", "https://images-na.ssl-images-amazon.com/images/I/31qwualUaLL._SR600,315_SCLZZZZZZZ_.jpg", "PS4", false, 200 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
