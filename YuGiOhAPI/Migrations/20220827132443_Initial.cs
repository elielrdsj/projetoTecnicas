using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YuGiOhAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrlSmall = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardImages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CardPrice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardMarketPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tcgPlayerPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ebayPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amazonPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coolstuffincPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPrice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CardSets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    setName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    setCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    setRarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    setRarityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    setPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "YugiohDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    archetype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    atribute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    setid = table.Column<int>(type: "int", nullable: false),
                    imageid = table.Column<int>(type: "int", nullable: false),
                    priceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YugiohDb", x => x.id);
                    table.ForeignKey(
                        name: "FK_YugiohDb_CardImages_imageid",
                        column: x => x.imageid,
                        principalTable: "CardImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YugiohDb_CardPrice_priceid",
                        column: x => x.priceid,
                        principalTable: "CardPrice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YugiohDb_CardSets_setid",
                        column: x => x.setid,
                        principalTable: "CardSets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YugiohDb_imageid",
                table: "YugiohDb",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_YugiohDb_priceid",
                table: "YugiohDb",
                column: "priceid");

            migrationBuilder.CreateIndex(
                name: "IX_YugiohDb_setid",
                table: "YugiohDb",
                column: "setid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YugiohDb");

            migrationBuilder.DropTable(
                name: "CardImages");

            migrationBuilder.DropTable(
                name: "CardPrice");

            migrationBuilder.DropTable(
                name: "CardSets");
        }
    }
}
