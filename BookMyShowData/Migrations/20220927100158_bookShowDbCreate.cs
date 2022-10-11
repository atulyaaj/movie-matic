using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowData.Migrations
{
    public partial class bookShowDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "theatres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theatres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "showTimings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showTimings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_showTimings_movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_showTimings_theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_showTimings_MovieId",
                table: "showTimings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_showTimings_TheatreId",
                table: "showTimings",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "showTimings");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "theatres");
        }
    }
}
