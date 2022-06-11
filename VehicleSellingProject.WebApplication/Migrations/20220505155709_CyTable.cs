using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class CyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "CylinderId",
                table: "Vehicle",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Cylinder",
                columns: table => new
                {
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    BodyTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Qty = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cylinder", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Cylinder_BodyType",
                        column: x => x.BodyTypeCode,
                        principalTable: "BodyType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CylinderId",
                table: "Vehicle",
                column: "CylinderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cylinder_BodyTypeCode",
                table: "Cylinder",
                column: "BodyTypeCode");

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

            migrationBuilder.DropTable(
                name: "Cylinder");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_CylinderId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CylinderId",
                table: "Vehicle");
        }
    }
}
