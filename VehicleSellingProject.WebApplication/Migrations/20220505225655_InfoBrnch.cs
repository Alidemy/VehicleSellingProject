using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class InfoBrnch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellingBranch",
                columns: table => new
                {
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    BranchNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchTelephone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingBranch", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SellingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingBranchId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellingInfo_SellingBranch_SellingBranchId",
                        column: x => x.SellingBranchId,
                        principalTable: "SellingBranch",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingInfo_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellingInfo_SellingBranchId",
                table: "SellingInfo",
                column: "SellingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingInfo_VehicleId",
                table: "SellingInfo",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellingInfo");

            migrationBuilder.DropTable(
                name: "SellingBranch");
        }
    }
}
