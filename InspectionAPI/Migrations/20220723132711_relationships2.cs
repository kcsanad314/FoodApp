using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionAPI.Migrations
{
    public partial class relationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_UserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_UserId",
                table: "Restaurants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_UserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_UserId",
                table: "Restaurants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
