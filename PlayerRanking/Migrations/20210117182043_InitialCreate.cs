using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayerRanking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoritePlayers",
                columns: table => new
                {
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatlId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeAtRankDate = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true),
                    IsTie = table.Column<bool>(type: "bit", nullable: true),
                    NbrEventsPlayed = table.Column<int>(type: "int", nullable: true),
                    PrevRank = table.Column<int>(type: "int", nullable: true),
                    PrevPoints = table.Column<int>(type: "int", nullable: true),
                    PointsDropping = table.Column<int>(type: "int", nullable: true),
                    NextBestPoints = table.Column<int>(type: "int", nullable: true),
                    LastWeekPosMove = table.Column<int>(type: "int", nullable: true),
                    PlayerGladiatorImageCmsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerHeadshotImageCmsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePlayers", x => x.PlayerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritePlayers");
        }
    }
}
