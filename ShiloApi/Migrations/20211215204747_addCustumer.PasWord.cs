using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiloApi.Migrations
{
    public partial class addCustumerPasWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasWord",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasWord",
                table: "Customers");
        }
    }
}
