using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class InfoBrach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellingInfo_SellingBranch_SellingBranchId",
                table: "SellingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SellingInfo_Vehicle_VehicleId",
                table: "SellingInfo");

            migrationBuilder.DropIndex(
                name: "IX_SellingInfo_SellingBranchId",
                table: "SellingInfo");

            migrationBuilder.DropColumn(
                name: "SellingBranchId",
                table: "SellingInfo");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "SellingInfo",
                newName: "BranchID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SellingInfo",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerTel",
                table: "SellingInfo",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerName",
                table: "SellingInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellingInfo_BranchID",
                table: "SellingInfo",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_SellingInfo_SellingBranch",
                table: "SellingInfo",
                column: "BranchID",
                principalTable: "SellingBranch",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellingInfo_Vehicle",
                table: "SellingInfo",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellingInfo_SellingBranch",
                table: "SellingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SellingInfo_Vehicle",
                table: "SellingInfo");

            migrationBuilder.DropIndex(
                name: "IX_SellingInfo_BranchID",
                table: "SellingInfo");

            migrationBuilder.RenameColumn(
                name: "BranchID",
                table: "SellingInfo",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SellingInfo",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerTel",
                table: "SellingInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerName",
                table: "SellingInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<byte>(
                name: "SellingBranchId",
                table: "SellingInfo",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellingInfo_SellingBranchId",
                table: "SellingInfo",
                column: "SellingBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellingInfo_SellingBranch_SellingBranchId",
                table: "SellingInfo",
                column: "SellingBranchId",
                principalTable: "SellingBranch",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SellingInfo_Vehicle_VehicleId",
                table: "SellingInfo",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
