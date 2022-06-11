using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class vehiclModel2Int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Model",
                table: "Vehicle",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicle",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
