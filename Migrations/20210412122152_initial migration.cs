using Microsoft.EntityFrameworkCore.Migrations;

namespace EindopdrachtBackendDevelopment.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    CareerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Poles = table.Column<int>(type: "int", nullable: false),
                    FastestLaps = table.Column<int>(type: "int", nullable: false),
                    DriverChampionships = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Career", x => x.CareerId);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    SponsorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.SponsorId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceNumber = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Driver_Career_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Career",
                        principalColumn: "CareerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSponsors",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SponsorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSponsors", x => new { x.TeamId, x.SponsorId });
                    table.ForeignKey(
                        name: "FK_TeamSponsors_Sponsor_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsor",
                        principalColumn: "SponsorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSponsors_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Career",
                columns: new[] { "CareerId", "DriverChampionships", "FastestLaps", "Poles", "Wins" },
                values: new object[,]
                {
                    { 1, 0, 4, 7, 2 },
                    { 2, 0, 2, 0, 0 },
                    { 3, 4, 38, 57, 53 },
                    { 4, 0, 1, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "Location", "TeamName" },
                values: new object[,]
                {
                    { 1, "Italy", "Scuderia Ferrari" },
                    { 2, "United Kingdom", "McLaren" },
                    { 3, "United Kingdom", "Aston Martin" }
                });

            migrationBuilder.InsertData(
                table: "Driver",
                columns: new[] { "DriverId", "CareerId", "FirstName", "LastName", "Nationality", "RaceNumber", "TeamId" },
                values: new object[,]
                {
                    { 1, 1, "Charles", "Leclerc", "Monégasque", 16, 1 },
                    { 2, 2, "Lando", "Norris", "British", 4, 2 },
                    { 3, 3, "Sebastian", "Vettel", "German", 5, 3 },
                    { 4, 4, "Carlos", "Sainz", "Spanish", 55, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CareerId",
                table: "Driver",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSponsors_SponsorId",
                table: "TeamSponsors",
                column: "SponsorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "TeamSponsors");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropTable(
                name: "Sponsor");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
