using Microsoft.EntityFrameworkCore.Migrations;

namespace STC.Customer.Infrastructure.Migrations
{
    public partial class CustomerTableAddDeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Customers");
        }
    }
}
