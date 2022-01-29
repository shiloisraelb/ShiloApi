using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiloApi.Migrations
{
    public partial class Ordersprodact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodacts_Orders_orderdate",
                table: "Prodacts");

            migrationBuilder.DropIndex(
                name: "IX_Prodacts_orderdate",
                table: "Prodacts");

            migrationBuilder.DropColumn(
                name: "orderdate",
                table: "Prodacts");

            migrationBuilder.AddColumn<string>(
                name: "prodactbandName",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_prodactbandName",
                table: "Orders",
                column: "prodactbandName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Prodacts_prodactbandName",
                table: "Orders",
                column: "prodactbandName",
                principalTable: "Prodacts",
                principalColumn: "bandName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Prodacts_prodactbandName",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_prodactbandName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "prodactbandName",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "orderdate",
                table: "Prodacts",
                type: "datetime2",
                nullable: true);

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
    }
}
