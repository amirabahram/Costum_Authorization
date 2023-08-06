using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBAC.Presistence.Migrations
{
    public partial class roleAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae0cf25d-0984-4cb4-b3b4-352c32d7d5ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b39c9a57-9894-4095-b287-f975edd65ac0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0737eace-2d8c-45aa-a1cd-5ed290be87b6", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63d143e2-20b6-4933-88ac-d9ad1d7c64ad", "1", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a5c89bf-2fd6-4845-b06c-1e08f97ca176", "1", "developer", "developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0737eace-2d8c-45aa-a1cd-5ed290be87b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63d143e2-20b6-4933-88ac-d9ad1d7c64ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a5c89bf-2fd6-4845-b06c-1e08f97ca176");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae0cf25d-0984-4cb4-b3b4-352c32d7d5ea", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b39c9a57-9894-4095-b287-f975edd65ac0", "1", "User", "User" });
        }
    }
}
