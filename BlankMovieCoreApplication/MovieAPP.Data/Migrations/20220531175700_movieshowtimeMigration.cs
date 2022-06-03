using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPP.Data.Migrations
{
    public partial class movieshowtimeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieShowTimeModels",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheaterId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieShowTimeModels", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_movieShowTimeModels_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieShowTimeModels_theaterModel_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "theaterModel",
                        principalColumn: "TheaterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimeModels_MovieId",
                table: "movieShowTimeModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimeModels_TheaterId",
                table: "movieShowTimeModels",
                column: "TheaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieShowTimeModels");
        }
    }
}
