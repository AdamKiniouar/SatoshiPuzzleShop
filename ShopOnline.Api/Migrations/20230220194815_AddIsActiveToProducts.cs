using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.Api.Migrations
{
    public partial class AddIsActiveToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DbCreationDate",
                value: new DateTime(2023, 2, 20, 20, 48, 14, 715, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DbCreationDate",
                value: new DateTime(2023, 2, 20, 20, 48, 14, 715, DateTimeKind.Local).AddTicks(1826));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductCategories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DbCreationDate",
                value: new DateTime(2023, 2, 19, 16, 34, 43, 993, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DbCreationDate",
                value: new DateTime(2023, 2, 19, 16, 34, 43, 993, DateTimeKind.Local).AddTicks(4177));
        }
    }
}
