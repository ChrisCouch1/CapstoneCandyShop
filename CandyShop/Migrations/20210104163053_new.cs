using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyShop.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f4f3fd1-61f6-49c4-afba-f677d1b75305");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c39751f-3351-4fe3-94e9-5fe310486351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6d98d9b-0725-44fa-a293-aba485675674");

            migrationBuilder.DropColumn(
                name: "dateEnd",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "dateStart",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "dateEnd",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "dateStart",
                table: "Employee");

            migrationBuilder.AddColumn<DateTime>(
                name: "breakEnd",
                table: "Manager",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "breakStart",
                table: "Manager",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "breakEnd",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "breakStart",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1852141-b5de-4aea-84da-9701a5d0a0d4", "09fee960-da29-4710-8f04-607fb7365af0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23c825f4-d99d-4592-a0e7-cb8173b9f0a8", "c9bf9179-4bba-48b3-8c12-3110ca709b57", "Manager", "MGR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f38faee7-3df3-4475-8d52-aacb062bc2da", "eee173e8-f8c4-4469-bb0d-2bcb466ac8ba", "Employee", "EMP" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23c825f4-d99d-4592-a0e7-cb8173b9f0a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1852141-b5de-4aea-84da-9701a5d0a0d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f38faee7-3df3-4475-8d52-aacb062bc2da");

            migrationBuilder.DropColumn(
                name: "breakEnd",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "breakStart",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "breakEnd",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "breakStart",
                table: "Employee");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateEnd",
                table: "Manager",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateStart",
                table: "Manager",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateEnd",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateStart",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6d98d9b-0725-44fa-a293-aba485675674", "7a4ecc65-0b5f-473c-ae73-805c8f992411", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c39751f-3351-4fe3-94e9-5fe310486351", "ffeb04e3-34bc-4783-b2de-56b393d1ae5f", "Manager", "MGR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f4f3fd1-61f6-49c4-afba-f677d1b75305", "bc1008dd-f6c5-441f-82e8-75bb0dd8b9da", "Employee", "EMP" });
        }
    }
}
