using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceAPI.Migrations
{
    public partial class RemovedPricePerItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerItem",
                table: "CartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PricePerItem",
                table: "CartItems",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
