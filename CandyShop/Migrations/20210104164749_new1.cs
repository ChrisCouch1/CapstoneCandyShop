using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyShop.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "Manager",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4e6291d-e534-44d2-833c-c6a5150cdcbb", "571c9837-e6dd-4f9d-90cd-0aa22723d27a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40bd285d-a957-4519-bc93-90c8be3d6e8c", "4b354e11-5bc9-4307-84c1-738b4f8bb605", "Manager", "MGR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89d8d157-4e26-4c41-926d-a12fe6fd339b", "92fc717e-b79c-4a89-8c2d-795dbaf022af", "Employee", "EMP" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40bd285d-a957-4519-bc93-90c8be3d6e8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89d8d157-4e26-4c41-926d-a12fe6fd339b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e6291d-e534-44d2-833c-c6a5150cdcbb");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNumber",
                table: "Manager",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "phoneNumber",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
