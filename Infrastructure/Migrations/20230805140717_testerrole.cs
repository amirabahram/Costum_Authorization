using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBAC.Presistence.Migrations
{
    public partial class testerrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4484d264-85f5-4e17-8967-5ceca6346237");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6971221-d9fe-4b54-8079-e9b216491c91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5c20ade-9f09-42e6-9bc2-1603773b7327");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9733a4c-81ce-49b9-8936-5f726f89e18d", "1", "developer", "developer" },
                    { "bf0282e8-856f-4068-b924-f77a29100f04", "1", "Admin", "Admin" },
                    { "c116f607-e8f8-4419-acdd-bef9768dc5fb", "1", "tester", "tester" },
                    { "f8601894-fa29-4d0b-b75f-ad98a6bd9a59", "1", "User", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9733a4c-81ce-49b9-8936-5f726f89e18d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf0282e8-856f-4068-b924-f77a29100f04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c116f607-e8f8-4419-acdd-bef9768dc5fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8601894-fa29-4d0b-b75f-ad98a6bd9a59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4484d264-85f5-4e17-8967-5ceca6346237", "1", "developer", "developer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6971221-d9fe-4b54-8079-e9b216491c91", "1", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5c20ade-9f09-42e6-9bc2-1603773b7327", "1", "Admin", "Admin" });
        }
    }
}
