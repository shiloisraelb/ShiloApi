using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiloApi.Migrations
{
    public partial class addCustumeremail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Customers");
        }
    }
}
