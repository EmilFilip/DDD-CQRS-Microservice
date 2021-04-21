using Microsoft.EntityFrameworkCore.Migrations;

namespace STC.Customer.Infrastructure.Migrations
{
    public partial class CustomerTableAddUpdatedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Updated",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Customers");
        }
    }
}
