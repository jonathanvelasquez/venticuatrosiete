using Microsoft.EntityFrameworkCore.Migrations;

namespace venticuatrosiete.Web.Migrations
{
    public partial class DeliveriesProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Delivery",
                table: "Products",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "Products");
        }
    }
}
