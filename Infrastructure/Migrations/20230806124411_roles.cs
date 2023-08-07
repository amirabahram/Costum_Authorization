using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBAC.Presistence.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PermittedRole",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "PermittedRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermittedRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermittedRoles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PermittedRoles_ProductId",
                table: "PermittedRoles",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermittedRoles");

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

            migrationBuilder.AddColumn<string>(
                name: "PermittedRole",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
