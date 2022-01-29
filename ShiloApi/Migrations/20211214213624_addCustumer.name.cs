using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiloApi.Migrations
{
    public partial class addCustumername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodacts_Orders_orderCustumerAddres",
                table: "Prodacts");

            migrationBuilder.DropIndex(
                name: "IX_Prodacts_orderCustumerAddres",
                table: "Prodacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderCustumerAddres",
                table: "Prodacts");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Prodacts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "orderdate",
                table: "Prodacts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustumerAddres",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "IX_Prodacts_orderdate",
                table: "Prodacts",
                column: "orderdate");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodacts_Orders_orderdate",
                table: "Prodacts",
                column: "orderdate",
                principalTable: "Orders",
                principalColumn: "date",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodacts_Orders_orderdate",
                table: "Prodacts");

            migrationBuilder.DropIndex(
                name: "IX_Prodacts_orderdate",
                table: "Prodacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Prodacts");

            migrationBuilder.DropColumn(
                name: "orderdate",
                table: "Prodacts");

            migrationBuilder.AddColumn<string>(
                name: "orderCustumerAddres",
                table: "Prodacts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustumerAddres",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "CustumerAddres");

            migrationBuilder.CreateIndex(
                name: "IX_Prodacts_orderCustumerAddres",
                table: "Prodacts",
                column: "orderCustumerAddres");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodacts_Orders_orderCustumerAddres",
                table: "Prodacts",
                column: "orderCustumerAddres",
                principalTable: "Orders",
                principalColumn: "CustumerAddres",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
