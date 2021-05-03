using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STC.Customer.Infrastructure.Migrations
{
    public partial class CustomerTableAddDeletedAtColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Customers");
        }
    }
}
