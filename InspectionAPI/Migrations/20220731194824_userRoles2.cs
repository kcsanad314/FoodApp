using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionAPI.Migrations
{
    public partial class userRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f872bdb-44f8-4c32-a41e-ae2eab398200");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfb711ef-35f6-4881-8214-cf34c74cd900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f21eb12f-a9e7-4766-9047-a4c0796fe74a");

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e78a901-15c8-46cc-b3e1-46a944ceea59", "9c26b712-b28f-455d-a0f6-2c64bf7c4b6f", "Courier", "COURIER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea2b7e6f-d9d7-4bfe-9273-9dccbd093ecf", "b4677981-2078-49cd-b8cc-98da8111b8fc", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe33f7af-b2fa-430e-a844-638fc4609cf1", "a8c7b722-92e1-4604-a10b-f614125e7b59", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e78a901-15c8-46cc-b3e1-46a944ceea59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea2b7e6f-d9d7-4bfe-9273-9dccbd093ecf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe33f7af-b2fa-430e-a844-638fc4609cf1");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f872bdb-44f8-4c32-a41e-ae2eab398200", "c891937a-b6aa-469c-a1aa-c62a83ff998d", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfb711ef-35f6-4881-8214-cf34c74cd900", "70687282-2bad-401d-9027-ae5b6f0185e6", "Courier", "COURIER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f21eb12f-a9e7-4766-9047-a4c0796fe74a", "39d517e3-398d-4dc1-86a0-ab5934f74d56", "Customer", "CUSTOMER" });
        }
    }
}
