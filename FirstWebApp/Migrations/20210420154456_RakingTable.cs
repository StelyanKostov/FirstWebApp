using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstWebApp.Migrations
{
    public partial class RakingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RankingPremiumSmartphones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    SmartphoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankingPremiumSmartphones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RankingPremiumSmartphones_Smartphones_SmartphoneId",
                        column: x => x.SmartphoneId,
                        principalTable: "Smartphones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RankingPremiumSmartphones_SmartphoneId",
                table: "RankingPremiumSmartphones",
                column: "SmartphoneId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RankingPremiumSmartphones");
        }
    }
}
