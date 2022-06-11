using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class vehiclModel2Varchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sedan");

            migrationBuilder.DropTable(
                name: "EngineDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicle",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Model",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "EngineDetails",
                columns: table => new
                {
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    Cylinders = table.Column<byte>(type: "tinyint", nullable: false),
                    EngineSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineDetails", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Sedan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineDetailsCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sedan_EngineDetails",
                        column: x => x.EngineDetailsCode,
                        principalTable: "EngineDetails",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sedan_EngineDetailsCode",
                table: "Sedan",
                column: "EngineDetailsCode");
        }
    }
}
