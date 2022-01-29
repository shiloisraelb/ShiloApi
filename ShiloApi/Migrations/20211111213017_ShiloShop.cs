using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiloApi.Migrations
{
    public partial class ShiloShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    log = table.Column<bool>(nullable: false),
                    CustumerID = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustumerID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentID = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    instrument = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    CustumerAddres = table.Column<string>(nullable: false),
                    CustumerID = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.CustumerAddres);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustumerID",
                        column: x => x.CustumerID,
                        principalTable: "Customers",
                        principalColumn: "CustumerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prodacts",
                columns: table => new
                {
                    bandName = table.Column<string>(maxLength: 16, nullable: false),
                    orderCustumerAddres = table.Column<string>(nullable: true),
                    conectionNumber = table.Column<int>(nullable: false),
                    instrument = table.Column<string>(nullable: true),
                     Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodacts", x => x.bandName);
                    table.ForeignKey(
                        name: "FK_Prodacts_Orders_orderCustumerAddres",
                        column: x => x.orderCustumerAddres,
                        principalTable: "Orders",
                        principalColumn: "CustumerAddres",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_name",
                table: "Customers",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustumerID",
                table: "Orders",
                column: "CustumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodacts_bandName",
                table: "Prodacts",
                column: "bandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodacts_orderCustumerAddres",
                table: "Prodacts",
                column: "orderCustumerAddres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodacts");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
