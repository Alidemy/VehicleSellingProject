using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class fkCylin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "CylinderId",
                table: "Vehicle",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CylinderId",
                table: "Vehicle",
                column: "CylinderId");


            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Cylinder",
                table: "Vehicle",
                column: "CylinderId",
                principalTable: "Cylinder",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Cylinder",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_CylinderId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CylinderId",
                table: "Vehicle");
        }
    }
}
