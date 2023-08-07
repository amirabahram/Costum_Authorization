using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBAC.Presistence.Migrations
{
    public partial class ProductRolesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermittedRoles");

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

            migrationBuilder.CreateTable(
                name: "ProductRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRoles_Products_ProductId",
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
                    { "4290725f-0860-4ec6-8baf-7a9737baaa65", "1", "tester", "tester" },
                    { "51ed110d-198a-4a43-b46c-547b652b01c1", "1", "developer", "developer" },
                    { "6a29a5bf-d7b4-4089-bdd8-e1cc7800bc9f", "1", "User", "User" },
                    { "f4820c6b-32d5-44ce-990a-fcb350cb0733", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRoles_ProductId",
                table: "ProductRoles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRoles_RoleId",
                table: "ProductRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4290725f-0860-4ec6-8baf-7a9737baaa65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51ed110d-198a-4a43-b46c-547b652b01c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a29a5bf-d7b4-4089-bdd8-e1cc7800bc9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4820c6b-32d5-44ce-990a-fcb350cb0733");

            migrationBuilder.CreateTable(
                name: "PermittedRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { "01c2d64d-4fe4-4811-b30c-ed135a7ee377", "1", "developer", "developer" },
                    { "33806021-b9d0-46a1-97d8-afd6d9261586", "1", "Admin", "Admin" },
                    { "8cdc7daf-cf2b-43d5-9e9b-30a100249e55", "1", "tester", "tester" },
                    { "9af73633-58c9-4492-90f0-2d1657b413f8", "1", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermittedRoles_ProductId",
                table: "PermittedRoles",
                column: "ProductId");
        }
    }
}
