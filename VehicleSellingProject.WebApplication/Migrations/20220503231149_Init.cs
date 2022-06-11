using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleSellingProject.WebApplication.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EngineDetails",
                columns: table => new
                {
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    EngineSize = table.Column<int>(type: "int", nullable: false),
                    Cylinders = table.Column<byte>(type: "tinyint", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    EngineDetailsCode = table.Column<byte>(type: "tinyint", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sedan");

            migrationBuilder.DropTable(
                name: "EngineDetails");
        }
    }
}
