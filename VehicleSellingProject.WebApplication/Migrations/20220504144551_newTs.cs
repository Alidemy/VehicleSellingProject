using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class newTs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyType",
                columns: table => new
                {
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Door",
                columns: table => new
                {
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    BodyTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Qty = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Door", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Door_BodyType",
                        column: x => x.BodyTypeCode,
                        principalTable: "BodyType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EngineSize",
                columns: table => new
                {
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    BodyTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineSize", x => x.Code);
                    table.ForeignKey(
                        name: "FK_EngineSize_BodyType",
                        column: x => x.BodyTypeCode,
                        principalTable: "BodyType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BodyTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    EngineSizeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    DoorCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicle_BodyType",
                        column: x => x.BodyTypeCode,
                        principalTable: "BodyType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_Door",
                        column: x => x.DoorCode,
                        principalTable: "Door",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_EngineSize",
                        column: x => x.EngineSizeCode,
                        principalTable: "EngineSize",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Door_BodyTypeCode",
                table: "Door",
                column: "BodyTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EngineSize_BodyTypeCode",
                table: "EngineSize",
                column: "BodyTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BodyTypeCode",
                table: "Vehicle",
                column: "BodyTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DoorCode",
                table: "Vehicle",
                column: "DoorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_EngineSizeCode",
                table: "Vehicle",
                column: "EngineSizeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Door");

            migrationBuilder.DropTable(
                name: "EngineSize");

            migrationBuilder.DropTable(
                name: "BodyType");
        }
    }
}
