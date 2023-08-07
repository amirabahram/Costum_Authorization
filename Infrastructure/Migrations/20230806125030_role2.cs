using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBAC.Presistence.Migrations
{
    public partial class role2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b43556-8150-45d4-b33a-a9f96196f6d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41bb5394-45fc-4f39-a3ed-0bf5efd432c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aca75ec-e7cc-45bf-ae4d-bf60b7fd62c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be3ee54e-d76b-4a25-81af-d0ef42b2fa8b");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PermittedRoles",
                newName: "Role");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01c2d64d-4fe4-4811-b30c-ed135a7ee377", "1", "developer", "developer" },
                    { "33806021-b9d0-46a1-97d8-afd6d9261586", "1", "Admin", "Admin" },
                    { "8cdc7daf-cf2b-43d5-9e9b-30a100249e55", "1", "tester", "tester" },
                    { "9af73633-58c9-4492-90f0-2d1657b413f8", "1", "User", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c2d64d-4fe4-4811-b30c-ed135a7ee377");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33806021-b9d0-46a1-97d8-afd6d9261586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cdc7daf-cf2b-43d5-9e9b-30a100249e55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af73633-58c9-4492-90f0-2d1657b413f8");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "PermittedRoles",
                newName: "Title");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22b43556-8150-45d4-b33a-a9f96196f6d6", "1", "tester", "tester" },
                    { "41bb5394-45fc-4f39-a3ed-0bf5efd432c3", "1", "User", "User" },
                    { "8aca75ec-e7cc-45bf-ae4d-bf60b7fd62c3", "1", "developer", "developer" },
                    { "be3ee54e-d76b-4a25-81af-d0ef42b2fa8b", "1", "Admin", "Admin" }
                });
        }
    }
}
